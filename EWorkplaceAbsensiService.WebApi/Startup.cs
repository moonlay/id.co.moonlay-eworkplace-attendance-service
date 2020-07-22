using AutoMapper;
using EWorkplaceAbsensiService.Lib;
using EWorkplaceAbsensiService.Lib.Helpers.IdentityService;
using EWorkplaceAbsensiService.Lib.Helpers.ValidateService;
using EWorkplaceAbsensiService.Lib.Services.Absensis;
using EWorkplaceAbsensiService.Lib.Services.Activities;
using EWorkplaceAbsensiService.Lib.Services.ActivityCategories;
using EWorkplaceAbsensiService.Lib.Services.Projects;
using EWorkplaceAbsensiService.Lib.Services.Reports;
using EWorkplaceAbsensiService.Lib.Services.TaskManagement;
using EWorkplaceAbsensiService.Lib.Services.TimeSheets;
using EWorkplaceAbsensiService.WebApi.Uploads;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWorkplaceAbsensiService.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        private void RegisterServices(IServiceCollection services)
        {
            services
                .AddScoped<IIdentityService, IdentityService>()
                .AddScoped<IValidateService, ValidateService>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""))
            string connectionString = Configuration.GetConnectionString("DefaultConnection") ?? Configuration["DefaultConnection"];
            string authority = Configuration["Authority"];
            string clientId = Configuration["ClientId"];
            string secret = Configuration["Secret"];

            services
                //.AddDbContext<AbsensiDbContext>(options => options.UseSqlServer(connectionString))
                .AddDbContext<AbsensiDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("EWorkplaceAbsensiService.WebApi")))
                .AddTransient<IAbsensiService, AbsensiService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IActivityCategoryService, ActivityCategoryService>();
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<ITaskManagementService, TaskManagementService>();
            services.AddTransient<ITimeSheetService, TimeSheetService>();
            services.AddTransient<IReportService, ReportService>();

            RegisterServices(services);

            services
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 1);
                });

            string Secret = Configuration.GetValue<string>("Secret") ?? Configuration["Secret"];
            SymmetricSecurityKey Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = Key
                    };
                });

            services.AddCors(o => o.AddPolicy("CorePolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Content-Disposition", "api-version", "content-length", "content-md5", "content-type", "date", "request-id", "response-time");
            }));

            /*services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000/");
                });
            }); */

           /* services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:3000/"));
                c.AddPolicy("AllowSubdomain",
             builder =>
             {
                 builder.WithOrigins("http://localhost:3000/")
                  .SetIsOriginAllowedToAllowWildcardSubdomains();
             });
            });*/

            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));
            
            services
                .AddMvcCore()
                .AddApiExplorer()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddJsonOptions(options =>
                { options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                  //options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                });

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    In = "header",
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = "apiKey",
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                    {
                        "Bearer",
                        Enumerable.Empty<string>()
                    }
                });
                c.CustomSchemaIds(i => i.FullName);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AbsensiDbContext>();
                //ini untuk migrate
                //context.Database.Migrate();
            }
            app.UseAuthentication();
            app.UseCors("CorePolicy");

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });
        }
    }
}
