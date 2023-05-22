namespace LeaveManagementSystem.Common.Models
{
    public class EmployeeAllocationVM: EmployeeListVM
    {

       public List<LeaveAllocationVM> LeaveAllocations { get; set; }

    }
}
