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
        private const string API_VERSION = "1.0";

        public ReportController(IServiceProvider serviceProvider)
        {
            reportService = serviceProvider.GetService<IReportService>();
            identityService = serviceProvider.GetService<IIdentityService>();
            validateService = serviceProvider.GetService<IValidateService>();
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
            }catch(Exception e)
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
