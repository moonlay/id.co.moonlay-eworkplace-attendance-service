using Com.Moonlay.NetCore.Lib.Service;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Models;
using EWorkplaceAbsensiService.Lib.Services.Absensis;
using EWorkplaceAbsensiService.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EWorkplaceAbsensiService.Test.Controllers
{
    public class AbsensiControllerTest
    {
        
        private Mock<IServiceProvider> GetServiceProviderMock(IAbsensiService AbsensiService, IValidateService validateService)
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            serviceProviderMock.Setup(serviceProvider => serviceProvider.GetService(typeof(IAbsensiService)))
                .Returns(AbsensiService);

            serviceProviderMock.Setup(serviceProvider => serviceProvider.GetService(typeof(IValidateService)))
                .Returns(validateService);

            serviceProviderMock
                .Setup(serviceProvider => serviceProvider.GetService(typeof(IIdentityService)))
                .Returns(new IdentityService() { TimezoneOffset = 1, Token = "token", Username = "username" });


            return serviceProviderMock;
        }

        private AbsensiController GetController(IServiceProvider serviceProvider)
        {
            var user = new Mock<ClaimsPrincipal>();
            var claims = new Claim[]
            {
                new Claim("username", "unittestusername")
            };
            user.Setup(u => u.Claims).Returns(claims);

            var controller = (AbsensiController)Activator.CreateInstance(typeof(AbsensiController), serviceProvider);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext()
                {
                    User = user.Object
                }
            };
            controller.ControllerContext.HttpContext.Request.Headers["Authorization"] = "Bearer unittesttoken";
            controller.ControllerContext.HttpContext.Request.Headers["x-timezone-offset"] = "7";
            controller.ControllerContext.HttpContext.Request.Path = new PathString("/v1/unit-test");

            return controller;
        }
        private readonly DbSet<Absensi> _AbsensiDbSet;
        private int GetStatusCode(IActionResult response)
        {
            return (int)response.GetType().GetProperty("StatusCode").GetValue(response, null);
        }

        private ServiceValidationExeption GetServiceValidationException()
        {
            Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();
            List<ValidationResult> validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(new Absensi(), serviceProvider.Object, null);
            return new ServiceValidationExeption(validationContext, validationResults);
        }


        [Fact]
        public async Task Should_Success_Post_Data()
        {
            var AbsensiServiceMock = new Mock<IAbsensiService>();
            AbsensiServiceMock.Setup(AbsensiService => AbsensiService.Create(It.IsAny<Absensi>()))
                .ReturnsAsync(1);

            var validateServiceMock = new Mock<IValidateService>();
            validateServiceMock.Setup(validateService => validateService.Validate(It.IsAny<Absensi>()))
                .Verifiable();

            var serviceProviderMock = GetServiceProviderMock(AbsensiServiceMock.Object, validateServiceMock.Object);

            var controller = GetController(serviceProviderMock.Object);
            var response = await controller.Post(new Absensi() { //Code = "1", 
                Name = "AbsensiName" });

            Assert.Equal((int)HttpStatusCode.Created, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_Success_Post_Invalid_Data()
        {
            var AbsensiServiceMock = new Mock<IAbsensiService>();
            AbsensiServiceMock.Setup(AbsensiService => AbsensiService.Create(It.IsAny<Absensi>()))
                .ReturnsAsync(1);

            var validateServiceMock = new Mock<IValidateService>();
            validateServiceMock.Setup(validateService => validateService.Validate(It.IsAny<Absensi>()))
                .Throws(GetServiceValidationException());

            var serviceProviderMock = GetServiceProviderMock(AbsensiServiceMock.Object, validateServiceMock.Object);

            var controller = GetController(serviceProviderMock.Object);
            var response = await controller.Post(new Absensi());

            Assert.Equal((int)HttpStatusCode.BadRequest, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_Success_Delete_Data()
        {
            var AbsensiServiceMock = new Mock<IAbsensiService>();
            AbsensiServiceMock.Setup(AbsensiService => AbsensiService.Create(It.IsAny<Absensi>()))
                .ReturnsAsync(1);

            var validateServiceMock = new Mock<IValidateService>();
            validateServiceMock.Setup(validateService => validateService.Validate(It.IsAny<Absensi>()))
                .Verifiable();

            var serviceProviderMock = GetServiceProviderMock(AbsensiServiceMock.Object, validateServiceMock.Object);

            var controller = GetController(serviceProviderMock.Object);
            var response = await controller.Delete(new Absensi().Id);

            Assert.Equal((int)HttpStatusCode.NoContent, GetStatusCode(response));
        }

        [Fact]
        public async Task Should_Success_Update_Data()
        {
            var AbsensiServiceMock = new Mock<IAbsensiService>();
            AbsensiServiceMock.Setup(AbsensiService => AbsensiService.Create(It.IsAny<Absensi>()))
                .ReturnsAsync(1);

            var validateServiceMock = new Mock<IValidateService>();
            validateServiceMock.Setup(validateService => validateService.Validate(It.IsAny<Absensi>()))
                .Verifiable();

            var serviceProviderMock = GetServiceProviderMock(AbsensiServiceMock.Object, validateServiceMock.Object);

            var controller = GetController(serviceProviderMock.Object);
            var response = await controller.Put(new Absensi().Id, new Absensi());
            Assert.Equal((int)HttpStatusCode.NoContent, GetStatusCode(response));
        }
    }
}
