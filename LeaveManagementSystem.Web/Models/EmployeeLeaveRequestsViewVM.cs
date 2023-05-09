namespace LeaveManagementSystem.Web.Models
{
    public class EmployeeLeaveRequestsViewVM
    {
        public EmployeeLeaveRequestsViewVM(List<LeaveAllocationVM> leaveAllocations,List<LeaveRequestVM> leaveRequests)
        {
            LeaveAllocations = leaveAllocations;
            LeaveRequests = leaveRequests;
            
        }
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }

    }
}
