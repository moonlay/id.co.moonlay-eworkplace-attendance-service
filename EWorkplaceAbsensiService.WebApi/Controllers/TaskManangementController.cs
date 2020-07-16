using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.Activities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWorkplaceAbsensiService.WebApi.Helpers;
using EWorkplaceAbsensiService.Lib.Models;
using Com.Moonlay.NetCore.Lib.Service;
using EWorkplaceAbsensiService.Lib.Services.TaskManagement;

namespace EWorkplaceAbsensiService.WebApi.Controllers
{

    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/Task")]
    public class TaskManangementController : Controller
    {
        private readonly ITaskManagementService _taskService;
        private readonly IIdentityService identityService;
        private readonly IValidateService validateService;
        private const string API_VERSION = "1.0";

        public TaskManangementController(IServiceProvider serviceProvider)
        {
            _taskService = serviceProvider.GetService<ITaskManagementService>();
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
        public async Task<ActionResult> Get([FromQuery] string keyword, [FromQuery] int page = 1, [FromQuery] int size = 25)
        {
            try
            {
                VerifyUser();
                var query = _taskService.GetAll();
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
        public async Task<ActionResult> Post([FromBody] TaskManangement task)
        {
            try
            {
                VerifyUser();
                validateService.Validate(task);
                await _taskService.Create(task);
                return CreatedAtRoute("Get", new { Id = task.Id }, task);
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
        [HttpGet("/v{version:apiVersion}/TaskProject/{id}", Name = "Geet")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                VerifyUser();
                var employee = _taskService.GetTaskByProject(id);
                return Ok(employee);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpGet("{taskid}", Name = "Goat")]
        public async Task<ActionResult> Get(int taskid,int page)
        {
            try
            {
                VerifyUser();
                var employee = await _taskService.GetTaskById(taskid);
                return Ok(employee);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TaskManangement task)
        {
            try
            {
                VerifyUser();
                validateService.Validate(task);
                TaskManangement task1 = await _taskService.GetTaskById(id);
                await _taskService.Update(task1, task);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                VerifyUser();
                await _taskService.DeleteTask(id);
                return NoContent();
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
