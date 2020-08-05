using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Overtime : StandardEntity, IValidatableObject
    {
        [StringLength(500)]
        public string Name { get; set; }
        public Division Division { get; set; }
        public Status Status { get; set; }
        public KindDay KindOfDay { get; set; }
        public DateTimeOffset OvertimeDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration
        {
            get
            {
                return EndTime.Hour - StartTime.Hour;
            }
            set { }
        }
        public double ReportedExpense
        {
            get
            {
                return MealsReimbursment + TransportReimbursment;
            }
            set { }
        }
        public double MealsReimbursment { get; set; }
        public double TransportReimbursment { get; set; }
        public double ApprovedExpense { get; set; }
        public string Desc { get; set; }
        public string Comments { get; set; }
        public string FileUrl { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }

    }
}
