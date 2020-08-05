using System;
using System.Linq;
using System.Threading.Tasks;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.Transports;
using Microsoft.AspNetCore.Authorization;
using EWorkplaceAbsensiService.WebApi.Helpers;
using EWorkplaceAbsensiService.Lib.Models;
using Com.Moonlay.NetCore.Lib.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using EWorkplaceAbsensiService.WebApi.Uploads;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AutoMapper;

namespace EWorkplaceAbsensiService.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{version:apiVersion}/Transports")]
    public class TransportController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        private readonly IOptions<MyConfig> config;

        private readonly ITransportService _TransportService;
        private readonly IIdentityService _identityService;
        private readonly IValidateService _validateService;
        private const string API_VERSION = "1.0";

        public TransportController(IServiceProvider serviceProvider, IOptions<MyConfig> config, IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;

            this.config = config;

            _TransportService = serviceProvider.GetService<ITransportService>();
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
        public async Task<ActionResult> Post(Transport transport, IFormFile stream)
        {
            try
            {

                VerifyUser();
                _validateService.Validate(transport);

                //upload file
                if (CloudStorageAccount.TryParse(config.Value.StorageConnection, out CloudStorageAccount storageAccount))
                {
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer container = blobClient.GetContainerReference(config.Value.Container);

                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();
                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var finalString = new String(stringChars);
                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(finalString + stream.FileName);

                    string fileUrl = blockBlob?.Uri.ToString();
                    transport.FileUrl = fileUrl.ToString();

                    await blockBlob.UploadFromStreamAsync(stream.OpenReadStream());
                }
                else
                {
                    return null;
                }

                await _TransportService.Create(transport);
                return CreatedAtRoute("Get", new { Id = transport.Id }, transport);
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
        public async Task<ActionResult> Get()
        {
            try
            {
                VerifyUser();

                var query = _TransportService.GetQuery();
                
                return Ok(query);

            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                VerifyUser();

                var transport = await _TransportService.GetSingleById(id);
                
                return Ok(transport);
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Transport Transport)
        {
            try
            {
                VerifyUser();
                _validateService.Validate(Transport);
                Transport transportToUpdate = await _TransportService.GetSingleById(id);
                await _TransportService.Update(transportToUpdate, Transport);
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

        [HttpPost("approveStatus/{id}")]
        public async Task<ActionResult> PutApprove(int id, [FromBody] Transport Transport)
        {
            try
            {
                VerifyUser();
                _validateService.Validate(Transport);
                Transport transportToUpdate = await _TransportService.GetSingleById(id);
                await _TransportService.ApproveStatus(transportToUpdate, Transport);
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

        [HttpPost("rejectStatus/{id}")]
        public async Task<ActionResult> PutReject(int id, [FromBody] Transport Transport)
        {
            try
            {
                VerifyUser();
                _validateService.Validate(Transport);
                Transport transportToUpdate = await _TransportService.GetSingleById(id);
                await _TransportService.RejectStatus(transportToUpdate, Transport);
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
                await _TransportService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                var result = new ResultFormatter(API_VERSION, General.INTERNAL_ERROR_STATUS_CODE, e.Message)
                    .Fail();
                return StatusCode(General.INTERNAL_ERROR_STATUS_CODE, result);
            }
        }

        [HttpGet("exportXL")]
        public async Task<IActionResult> ExportAll()
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            try
            {
                VerifyUser();
                var all = _TransportService.GetQuery().ToList();
                var total = all.Select(t => t.ApprovedExpense).Sum();
                var div = all
                    .GroupBy(d => d.Division)
                    .Select(t => new { Division = t.Key, Value = t.Sum(g => g.ReportedExpense) });

                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    //sheet 1
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                    //worksheet.Cells.LoadFromCollection(all, true);
                    int totalRows = all.Count();
                    worksheet.Cells[1, 1].Value = "Id";
                    worksheet.Cells[1, 2].Value = "Nama";
                    worksheet.Cells[1, 3].Value = "Divisi";
                    worksheet.Cells[1, 4].Value = "Receipt Date";
                    worksheet.Cells[1, 5].Value = "Description";
                    worksheet.Cells[1, 6].Value = "Departure Location";
                    worksheet.Cells[1, 7].Value = "Destination Location";
                    worksheet.Cells[1, 8].Value = "Approved Expense";
                    worksheet.Cells[1, 9].Value = "Total";
                    //worksheet.Cells[1, 10].Value = "Divisi";

                    worksheet.Column(1).AutoFit();
                    worksheet.Column(2).AutoFit();
                    worksheet.Column(3).AutoFit();
                    worksheet.Column(4).AutoFit();
                    worksheet.Column(5).AutoFit();
                    worksheet.Column(6).AutoFit();
                    worksheet.Column(7).AutoFit();
                    worksheet.Column(8).AutoFit();
                    worksheet.Column(9).AutoFit();
                    worksheet.Column(10).AutoFit();

                    int i = 0;
                    for (int row = 2; row <= totalRows + 1; row++)
                    {
                        worksheet.Cells[row, 1].Value = all[i].Id;
                        worksheet.Cells[row, 2].Value = all[i].Name;
                        worksheet.Cells[row, 3].Value = all[i].Division;
                        worksheet.Cells[row, 4].Value = all[i].ReceiptDate;
                        worksheet.Cells[row, 5].Value = all[i].Desc;
                        worksheet.Cells[row, 6].Value = all[i].DepartureLocation;
                        worksheet.Cells[row, 7].Value = all[i].DestinationLocation;
                        worksheet.Cells[row, 8].Value = all[i].ApprovedExpense;
                        worksheet.Cells[row, 9].Value = total;
                        //worksheet.Cells[row, 10].Value = div;
                        i++;
                    }

                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"Transport-{DateTime.Now.ToString("dd-MM HH:mm")}.xlsx";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
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
