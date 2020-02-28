using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using AbsenApi.Models.DataManager;
using AbsenApi.Models.Repository;
using AbsenApi.uploads;

namespace AbsenApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("https://adminpagelur.azurewebsites.net/");
                });
            });


            // services.AddDbContext<MEmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://adminpagelur.azurewebsites.net/"));
                c.AddPolicy("AllowSubdomain",
             builder =>
             {
                 builder.WithOrigins("https://adminpagelur.azurewebsites.net/")
                  .SetIsOriginAllowedToAllowWildcardSubdomains();
             });
            });


            services.Configure<MyConfig>(Configuration.GetSection("MyConfig"));

            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
         
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee.API V1");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(options => options.WithOrigins("https://adminpagelur.azurewebsites.net/"));
            app.UseCors(MyAllowSpecificOrigins);
           app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            

        }
    }
}
