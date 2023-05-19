using LeaveManagementSystem.Web.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Models
{
    public class LeaveRequestVM :LeaveRequestCreateVM
    {
        public int Id { get; set; }
        [Display(Name = "Leave Type")]
        public LeaveTypeVM LeaveType { get; set; }
        [Display(Name="Date Requested")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateRequested { get; set; }
        [Display(Name = "Status")]
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string? RequestingEmployeeId { get; set; }
        public  EmployeeListVM Employee { get; set; }
    }
}
