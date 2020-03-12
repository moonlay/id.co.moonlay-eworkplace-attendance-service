using Com.Moonlay.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Absensi : StandardEntity, IValidatableObject
    {
       // [StringLength(100)]
       // public string Code { get; set; }

        [StringLength(500)]
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime CheckIn { get; set; }

        public string State { get; set; }

        public string Location { get; set; }
        public DateTime CheckOut { get; set; }
        public string Approval { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
        public string ProjectName { get; set; }
        public string HeadDivision { get; set; }
        public string ApprovalByAdmin { get; set; }
        public string CompanyName { get; set; }
        public string ClientName { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

           

            

            return validationResult;
        }
    }
}
