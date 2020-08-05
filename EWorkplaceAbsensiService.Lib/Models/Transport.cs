using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Transport : StandardEntity, IValidatableObject
    {
        [StringLength(500)]

        public string Name { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string Desc { get; set; }
        public string DepartureLocation { get; set; }
        public string DestinationLocation { get; set; }
        public double ReportedExpense { get; set; }
        public double ApprovedExpense { get; set; }
        public string Comments { get; set; }
        public Status Status { get; set; }
        public Division Division { get; set; }
        public string FileUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }

        
    }
}
