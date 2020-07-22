using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System;
using EWorkplaceAbsensiService.Lib.Models.Filters;
using EWorkplaceAbsensiService.WebApi.Helpers;
using EWorkplaceAbsensiService.Lib.Models;
using Com.Moonlay.NetCore.Lib.Service;

namespace EWorkplaceAbsensiService.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/Projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly IIdentityService identityService;
        private readonly IValidateService validateService;
        private const string API_VERSION = "1.0";

        public ProjectController(IServiceProvider serviceProvider)
        {
            projectService = serviceProvider.GetService<IProjectService>();
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
        public async Task<ActionResult> Get([FromQuery] string keyword, [FromQuery] ProjectFilter filter,[FromQuery] int page = 1,[FromQuery] int size = 25)
        {
            try
            {
                VerifyUser();
                var query = projectService.GetQuery();
                return Ok(query);
            }catch(Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                 .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Project project)
        {
            try
            {
                VerifyUser();
                validateService.Validate(project);
                await projectService.Create(project);
                return CreatedAtRoute("Get", new { Id = project.Id }, project);
            }
            catch (ServiceValidationExeption e)
            {
                var result = new ResultFormatter(API_VERSION, General.BAD_REQUEST_STATUS_CODE, General.BAD_REQUEST_MESSAGE)
                    .Fail(e);
                return BadRequest(result);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message + "\n" + e.InnerException != null ? e.InnerException.Message : "" + "\n" + e.StackTrace)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }
        [HttpGet("{id}", Name = "Got")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                VerifyUser();
                var employee = await projectService.GetSingleById(id);
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
        public async Task<ActionResult> Put(int id, [FromBody] Project project)
        {
            try
            {
                VerifyUser();
                validateService.Validate(project);
                Project employeeToUpdate = await projectService.GetSingleById(id);
                await projectService.Update(employeeToUpdate, project);
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
                await projectService.Delete(id);
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
