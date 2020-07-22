using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Report : StandardEntity, IValidatableObject
    {
        public int ProjectId { get; set; }
        public int TimesheetId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }
    }
}
