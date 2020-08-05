using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EWorkplaceAbsensiService.WebApi.Helpers;
using EWorkplaceAbsensiService.Lib.Models;
using Com.Moonlay.NetCore.Lib.Service;
using System.Threading;
using System.IO;
using OfficeOpenXml;
using EWorkplaceAbsensiService.Lib.Services.TimeSheets;

namespace EWorkplaceAbsensiService.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/Reports")]
    public class ReportController : Controller
    {

        private readonly IReportService reportService;
        private readonly IIdentityService identityService;
        private readonly IValidateService validateService;
        private readonly ITimeSheetService timeSheetService;
        private const string API_VERSION = "1.0";

        public ReportController(IServiceProvider serviceProvider)
        {
            reportService = serviceProvider.GetService<IReportService>();
            identityService = serviceProvider.GetService<IIdentityService>();
            validateService = serviceProvider.GetService<IValidateService>();
            timeSheetService = serviceProvider.GetService<ITimeSheetService>();
        }
        private void VerifyUser()
        {
            identityService.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
            identityService.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
            identityService.TimezoneOffset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]string keyword)
        {
            try
            {
                VerifyUser();
                var query = reportService.GetAll();
                return Ok(query);
            } catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                 .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpGet("/v{version:apiVersion}/Reports/Excel", Name = "Report Excel")]
         public async Task<IActionResult> ExportV2()
         {
             ExcelPackage.LicenseContext = LicenseContext.Commercial;
             try
             {
                 VerifyUser();
                var report = timeSheetService.GetExcel();
                
                 var memory = new MemoryStream();

                 using(var package = new ExcelPackage(memory))
                 {
                     var workSheet = package.Workbook.Worksheets.Add("Sheet 1");
                     int totalrows = report.Count();
                     workSheet.Cells[1, 1].Value = "Id";
                     workSheet.Cells[1, 2].Value = "Employee Name";
                     workSheet.Cells[1, 3].Value = "Client Name";
                     workSheet.Cells[1, 4].Value = "Project Name";
                     workSheet.Cells[1, 5].Value = "Task Name";
                     workSheet.Cells[1, 6].Value = "Task Difficulty";
                     workSheet.Cells[1, 7].Value = "Start Date";
                     workSheet.Cells[1, 8].Value = "End Date";
                     workSheet.Cells[1, 9].Value = "Time";
                     workSheet.Cells[1, 10].Value = "Duration";

                     

                     int i = 0;
                     for(int row = 2; row < totalrows+1; row++)
                     {
                        workSheet.Cells[row, 1].Value = report[i].ReportId;
                        workSheet.Cells[row, 2].Value = report[i].EmployeeName;
                        workSheet.Cells[row, 3].Value = report[i].ClientName;
                        workSheet.Cells[row, 4].Value = report[i].ProjectName;
                        workSheet.Cells[row, 5].Value = report[i].TaskName;
                        workSheet.Cells[row, 6].Value = report[i].TaskDifficult;
                        string startdate = report[i].StartDate.ToString("dd/MM/yyyy");
                        workSheet.Cells[row, 7].Value = startdate;
                        string enddate = report[i].EndDate.ToString("dd/MM/yyyy");
                        workSheet.Cells[row, 8].Value = enddate;
                        var time = report[i].StartTime + " - " + report[i].EndTime;
                        workSheet.Cells[row, 9].Value = time;
                        var duration = report[i].Duration + " ";
                        workSheet.Cells[row, 10].Value = duration;
                        i++;

                     }
                     workSheet.Column(1).AutoFit();
                     workSheet.Column(2).AutoFit();
                     workSheet.Column(3).AutoFit();
                     workSheet.Column(4).AutoFit();
                     workSheet.Column(5).AutoFit();
                     workSheet.Column(6).AutoFit();
                     workSheet.Column(7).AutoFit();
                     workSheet.Column(8).AutoFit();
                     workSheet.Column(9).AutoFit();
                     package.Save();

                 }
                 memory.Position = 0;
                 string excelName = $"Report-{DateTime.Now.ToString("ddMMyyyy")}.xlsx";



                 return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

             }
             catch (Exception e)
             {
                 var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                     .Fail();
                 return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
             }

         }
        [HttpGet("/v{version:apiVersion}/Reports/Excel/{projectid}/{empid}", Name = "Report Excel by project")]
        public async Task<IActionResult> ExportV2(int projectid,int empid)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                VerifyUser();
                var report = timeSheetService.GetExcel(projectid,empid);

                var memory = new MemoryStream();

                using (var package = new ExcelPackage(memory))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet 1");
                    int totalrows = report.Count();
                    workSheet.Cells[1, 1].Value = "Id";
                    workSheet.Cells[1, 2].Value = "Employee Name";
                    workSheet.Cells[1, 3].Value = "Client Name";
                    workSheet.Cells[1, 4].Value = "Project Name";
                    workSheet.Cells[1, 5].Value = "Task Name";
                    workSheet.Cells[1, 6].Value = "Task Difficulty";
                    workSheet.Cells[1, 7].Value = "Start Date";
                    workSheet.Cells[1, 8].Value = "End Date";
                    workSheet.Cells[1, 9].Value = "Time";
                    workSheet.Cells[1, 10].Value = "Duration";



                    int i = 0;
                    for (int row = 2; row <= totalrows + 1; row++)
                    {
                        workSheet.Cells[row, 1].Value = report[i].ReportId;
                        workSheet.Cells[row, 2].Value = report[i].EmployeeName;
                        workSheet.Cells[row, 3].Value = report[i].ClientName;
                        workSheet.Cells[row, 4].Value = report[i].ProjectName;
                        workSheet.Cells[row, 5].Value = report[i].TaskName;
                        workSheet.Cells[row, 6].Value = report[i].TaskDifficult;
                        string startdate = report[i].StartDate.ToString("dd/MM/yyyy");
                        workSheet.Cells[row, 7].Value = startdate;
                        string enddate = report[i].EndDate.ToString("dd/MM/yyyy");
                        workSheet.Cells[row, 8].Value = enddate;
                        var time = report[i].StartTime + " - " + report[i].EndTime;
                        workSheet.Cells[row, 9].Value = time;
                        var duration = report[i].Duration + " ";
                        workSheet.Cells[row, 10].Value = duration;
                        i++;

                    }
                    workSheet.Column(1).AutoFit();
                    workSheet.Column(2).AutoFit();
                    workSheet.Column(3).AutoFit();
                    workSheet.Column(4).AutoFit();
                    workSheet.Column(5).AutoFit();
                    workSheet.Column(6).AutoFit();
                    workSheet.Column(7).AutoFit();
                    workSheet.Column(8).AutoFit();
                    workSheet.Column(9).AutoFit();
                    package.Save();

                }
                memory.Position = 0;
                string excelName = $"Report-{DateTime.Now.ToString("ddMMyyyy")}.xlsx";



                return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Report report)
        {
            try
            {
                VerifyUser();
                validateService.Validate(report);
                await reportService.Create(report);
                return CreatedAtRoute("Get", new { Id = report.Id }, report);
            }
            catch (ServiceValidationExeption e)
            {
                var result = new ResultFormatter(API_VERSION, General.BAD_REQUEST_STATUS_CODE, General.BAD_REQUEST_MESSAGE)
                    .Fail(e);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
    }
}
