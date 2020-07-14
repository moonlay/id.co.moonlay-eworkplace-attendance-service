using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class TaskManangement : StandardEntity, IValidatableObject
    {
        [StringLength(500)]
        public string TaskName { get; set; }
        public int TaskStatus { get; set; }
        public int TaskPriority { get; set; }
        public int ManHour { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TaskDifficulty { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int ProjectId { get; set; }

    }
}
