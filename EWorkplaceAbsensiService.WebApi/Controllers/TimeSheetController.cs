using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.TimeSheets;
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
    [Route("v{version:apiVersion}/TimeSheet")]
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService timeSheetService;
        private readonly IIdentityService identityService;
        private readonly IValidateService validateService;
        private const string API_VERSION = "1.0";

        public TimeSheetController(IServiceProvider serviceProvider)
        {
            timeSheetService = serviceProvider.GetService<ITimeSheetService>();
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
        public async Task<ActionResult> Get([FromQuery] string keyword)
        {
            try
            {
                VerifyUser();
                var query = timeSheetService.getAll();
                return Ok(query);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                 .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TimeSheet timeSheet)
        {
            try
            {
                VerifyUser();
                validateService.Validate(timeSheet);
                await timeSheetService.Create(timeSheet);
                return CreatedAtRoute("Get", new { Id = timeSheet.Id }, timeSheet);
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
        [HttpGet("/v{version:apiVersion}/TimeSheet/Project/{id}",Name ="Get By Project")]
        public async Task<ActionResult> Get(int id,int page)
        {
            try
            {
                VerifyUser();
                var timesheet = timeSheetService.getByProjectId(id);
                return Ok(timesheet);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpGet("/v{version:apiVersion}/TimeSheet/Project/{projectid}/{empid}", Name = "Get By Project And Emp")]
        public async Task<ActionResult> Get(int projectid, int empid,int page)
        {
            try
            {
                VerifyUser();
                var timesheet = timeSheetService.getByProjectAndEmployee(projectid,empid);
                return Ok(timesheet);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }

        [HttpGet("{id}",Name="GetTimeSheetDetail")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                VerifyUser();
                var timesheet = await timeSheetService.GetTimeSheetById(id);
                return Ok(timesheet);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                VerifyUser();
                await timeSheetService.DeleteTime(id);
                return NoContent();
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] TimeSheet timeSheet)
        {
            try
            {
                VerifyUser();
                validateService.Validate(timeSheet);
                TimeSheet timeSheetUpdate = await timeSheetService.GetTimeSheetById(id);
                await timeSheetService.Update(timeSheetUpdate, timeSheet);
                return NoContent();
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
