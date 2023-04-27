using LeaveManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models
{
    public class EmployeeAllocationVM: EmployeeListVM
    {

       public List<LeaveAllocationVM> LeaveAllocations { get; set; }

    }
}
