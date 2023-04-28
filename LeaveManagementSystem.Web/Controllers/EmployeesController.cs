using AutoMapper;
using LeaveManagementSystem.Web.Constants;
using LeaveManagementSystem.Web.Contracts;
using LeaveManagementSystem.Web.Data;
using LeaveManagementSystem.Web.Models;
using LeaveManagementSystem.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public EmployeesController(UserManager<Employee> userManager, IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _leaveAllocationRepository = leaveAllocationRepository;
        }


        public async Task<ActionResult> Index()
        {
            var employees = await  _userManager.GetUsersInRoleAsync(Roles.User);
            var model = _mapper.Map<List<EmployeeListVM>>(employees);
            return View(model);
        }

        // GET: EmployeesController/ViewAllocation/employeeId
        public async Task<ActionResult> ViewAllocation(string  id)
        {
            var model = await  _leaveAllocationRepository.GetEmployeeAllocations(id);
            return View(model);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/EditAllocation/5
        public async Task<ActionResult> EditAllocation(int id)
        {
            var model = await _leaveAllocationRepository.GetEmployeeAllocation(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
    

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
