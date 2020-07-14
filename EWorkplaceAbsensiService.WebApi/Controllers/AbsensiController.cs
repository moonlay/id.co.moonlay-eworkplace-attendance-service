using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EWorkplaceAbsensiService.WebApi.Helpers;
using Com.Moonlay.NetCore.Lib.Service;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Services.Absensis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EWorkplaceAbsensiService.Lib.Models.Filters;

namespace EWorkplaceAbsensiService.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/Absensis")]
    public class AbsensiController : Controller
    {
        private readonly IAbsensiService _AbsensiService;
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;
        private const string API_VERSION = "1.0";

       
        public AbsensiController(IServiceProvider serviceProvider)
        {
            _AbsensiService = serviceProvider.GetService<IAbsensiService>();
            _identityService = serviceProvider.GetService<IIdentityService>();
            _validateService = serviceProvider.GetService<IValidateService>();
        }

        private void VerifyUser()
        {
            _identityService.Username = User.Claims.ToArray().SingleOrDefault(p => p.Type.Equals("username")).Value;
            _identityService.Token = Request.Headers["Authorization"].FirstOrDefault().Replace("Bearer ", "");
            _identityService.TimezoneOffset = Convert.ToInt32(Request.Headers["x-timezone-offset"]);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Absensi Absensi)
        {
            try
            {
                VerifyUser();
                _validateService.Validate(Absensi);

                await _AbsensiService.Create(Absensi);
                return CreatedAtRoute(
                "Get",
                new { Id = Absensi.Id },
                Absensi);
                //var result = new ResultFormatter(API_VERSION, General.CREATED_STATUS_CODE, General.OK_MESSAGE)
                //  .Ok();
                //return Created(string.Concat(Request.Path, "/", 0), result);
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

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] string keyword, [FromQuery] AbsensiFilter filter, [FromQuery] int page = 1, [FromQuery] int size = 25)
        {
            try
            {
                VerifyUser();

                //var query = _AbsensiService.GetQuery();
                //if (!string.IsNullOrWhiteSpace(keyword))
                //  query = query.Where(entity => entity.Code.Contains(keyword) || entity.Name.Contains(keyword));
                /*var queryResult = await query
                  .Skip((page - 1) * size)
                  .Take(size)
                  .OrderByDescending(entity => entity.LastModifiedUtc)
                  .ToListAsync();

                var result = new ResultFormatter(API_VERSION, General.OK_STATUS_CODE, General.OK_MESSAGE)
                    .Ok(queryResult);
                return Ok(result);
*/
                var query = _AbsensiService.Find(filter);
                return Ok(query);

            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                VerifyUser();
                var employee = await _AbsensiService.GetSingleById(id);
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
        public async Task<ActionResult> Put(int id, [FromBody] Absensi Absensi)
        {
            try
            {
                VerifyUser();
                _validateService.Validate(Absensi);
                Absensi employeeToUpdate = await _AbsensiService.GetSingleById(id);
                await _AbsensiService.Update(employeeToUpdate, Absensi);
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
                await _AbsensiService.Delete(id);
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