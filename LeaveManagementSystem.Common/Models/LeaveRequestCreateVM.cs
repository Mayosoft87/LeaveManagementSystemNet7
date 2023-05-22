using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace LeaveManagementSystem.Common.Models
{
    public class LeaveRequestCreateVM
    {
        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int TotalDays { get; set; }
        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }
        public SelectList? LeaveTypes { get; set; }
        [Display(Name = "Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                //You call the Method and check.
                yield return new ValidationResult("The Start Date Must Be Before End Date", new[] { nameof(StartDate), nameof(EndDate) });
            }


            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("The Comments are to big", new[] { nameof(RequestComments)});
            }
        }

    }
}
