using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace AbsenApi.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AbsenceId { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

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
    }

}
