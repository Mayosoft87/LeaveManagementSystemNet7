using System.ComponentModel.DataAnnotations;

namespace LeaveManagementSystem.Web.Models
{
    public class LeaveTypeVM
    {
        public int Id  { get; set; }
        [Required]
        [Display(Name = "Leave Type")]
        public string Name { get; set; }
        [Required]
        [Range (1,25,ErrorMessage ="Please Enter a Valid Number")]
        [Display(Name="Default Number of Days")]
        public int DefaultDays { get; set; }
    }
}
