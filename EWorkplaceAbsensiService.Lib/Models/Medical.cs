﻿using Com.Moonlay.Models;
using EWorkplaceAbsensiService.Lib.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models
{
    public class Medical : StandardEntity, IValidatableObject
    {
        [StringLength(500)]
        double _cutting = 0.8;

        public string Name { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public string Desc { get; set; }
        public double ReportedExpense { get; set; }
        public double? ApprovedExpense { 
            get {
                return _cutting * ReportedExpense;
                }
            set {
                    
                } }
        public string Comments { get; set; }
        public string FileUrl { get; set; }
        public Status Status { get; set; }
        public Division Division { get; set; }

        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            return validationResult;
        }

        
    }
}
