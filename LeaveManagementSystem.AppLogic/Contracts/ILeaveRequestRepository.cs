using LeaveManagementSystem.Data;
using LeaveManagementSystem.Common.Models;

namespace LeaveManagementSystem.AppLogic.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<bool>  CreateLeaveRequest(LeaveRequestCreateVM model);
        Task<EmployeeLeaveRequestsViewVM> GetMyLeaveDetails();
        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);
        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);
        Task<AdminLeaveRequestsIndexVM> GetAdminLeaveRequestsList();
        Task ChangeApprovalStatus(int leaveRequestId, bool approved);
        Task CancelLeaveRequest(int? leaveRequestId);
    }
}
