using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagementSystem.AppLogic.Contracts;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Common.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace LeaveManagementSystem.AppLogic.Repositories
{
    public class LeaveRequestRepository :GenericRepository<LeaveRequest> , ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextcAccessor;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly UserManager<Employee> _userManager;
        private readonly AutoMapper.IConfigurationProvider _configurationProvider;
        private readonly IEmailSender _emailSender;

        public LeaveRequestRepository(ApplicationDbContext context, 
            IMapper mapper, 
            IHttpContextAccessor httpContextcAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            UserManager<Employee> userManager,
            AutoMapper.IConfigurationProvider configurationProvider,
            IEmailSender emailSender):base(context)
        {
            _context = context;
            _mapper = mapper;
            _httpContextcAccessor = httpContextcAccessor;
            _leaveAllocationRepository = leaveAllocationRepository;
            _userManager = userManager;
            _configurationProvider = configurationProvider;
            _emailSender = emailSender;
        }

        public async  Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;
            if (approved)
            { 
                var allocation = await _leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                await _leaveAllocationRepository.UpdateAsync(allocation);
            }
            await UpdateAsync(leaveRequest);


        }

        public async Task<bool>  CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            var user = await  _userManager.GetUserAsync(_httpContextcAccessor?.HttpContext?.User);
            var userLeaveAllocation = await _leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);
            if (userLeaveAllocation == null)
            {
                return false;
            }
            int daysRequested = (int)(model.EndDate.Value-model.StartDate.Value).TotalDays;

            if (daysRequested > userLeaveAllocation.NumberOfDays)
            { 
            return false;
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.UtcNow;
            leaveRequest.RequestingEmployeeId = user.Id;
            await AddAsync(leaveRequest);
            await _emailSender.SendEmailAsync(user.Email, "Leave Requested Submitted Successfully", $"Your leave request from " +
                $"{leaveRequest.StartDate} to {leaveRequest.EndDate} has been submitted for approval");
            return true;
           
        }

        public async Task<AdminLeaveRequestsIndexVM> GetAdminLeaveRequestsList()
        {
            var leaveRequests = await _context.leaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestsIndexVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q=> q.Approved ==true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved ==false ),
                LeaveRequests = _mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await  _context.leaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(_configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
           var leaveRequest = await _context.leaveRequests
                .Include(q=> q.LeaveType)
                .FirstOrDefaultAsync(q=> q.Id == id);
            if (leaveRequest == null)
            {
                return null;
            }
           var model = _mapper.Map<LeaveRequestVM>(leaveRequest);
           model.Employee = _mapper.Map<EmployeeListVM>(await _userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
           return model;
        }

        public async Task<EmployeeLeaveRequestsViewVM> GetMyLeaveDetails()
        {
            var user = await _userManager.GetUserAsync(_httpContextcAccessor?.HttpContext?.User);
            var allocations = (await _leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);
            var model = new EmployeeLeaveRequestsViewVM(allocations, requests);
            return model;
        }

        public async Task CancelLeaveRequest (int? leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            leaveRequest.DateModified = DateTime.UtcNow;
            await UpdateAsync(leaveRequest);
        }
    }
}
