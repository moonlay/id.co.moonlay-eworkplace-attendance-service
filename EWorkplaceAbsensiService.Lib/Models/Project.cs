using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Project : StandardEntity,IValidatableObject
    {

        [StringLength(500)]
        public string projectName { get; set; }
        public string contract { get; set; }
        public int status { get; set; }
        public string workType { get; set; }
        public string ClientName { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();
                
            return validationResult;
        }
        
    }
}
