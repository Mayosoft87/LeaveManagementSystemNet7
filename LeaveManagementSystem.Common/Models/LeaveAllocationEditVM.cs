namespace LeaveManagementSystem.Common.Models;

public class LeaveAllocationEditVM : LeaveAllocationVM
{
    public EmployeeListVM? Employee { get; set; }
    public int LeaveTypeId { get; set; }
    public string  EmployeeId { get; set; }
}
