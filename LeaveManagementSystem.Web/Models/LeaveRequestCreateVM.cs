﻿using LeaveManagementSystem.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagementSystem.Web.Models
{
    public class LeaveRequestCreateVM
    {
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public int TotalDays { get; set; }
        [Required]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Allocation Period")]
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