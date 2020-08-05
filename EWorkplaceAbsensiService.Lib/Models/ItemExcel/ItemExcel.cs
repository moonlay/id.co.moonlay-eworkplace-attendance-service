using System;
using System.Collections.Generic;
using System.Text;

namespace EWorkplaceAbsensiService.Lib.Models.ItemExcel.ItemExcel
{
    public class ItemExcel
    {

        public int ReportId { get; set; }
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string TaskName { get; set; }
        public string TaskDifficult {get;set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
