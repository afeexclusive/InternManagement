using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagment.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace EmployeeManagment
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("StudentDBConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddMvc(options => { var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddXmlSerializerFormatters();

            services.AddTransient<SampleUserRoleData>();
            services.AddScoped<IEmployeeReprository,  SQLEmployeeRepository>();
            services.AddScoped<IGuarantorRepo, SQLEmployeeRepository>();
            services.AddScoped<IManageEmployment, SQLEmployeeRepository>();
            services.AddScoped<IPayment, SQLEmployeeRepository>();
            services.AddScoped<IProgrammes, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SampleUserRoleData seeder)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute(); Not support so not working

            seeder.SeedAdminUser();




           app.UseRouting();

            app.UseAuthentication();

            app.UseCors();

            app.UseAuthorization();

            //app.UseMvc(); Not support so not working

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/secondfirst", async context =>
            //    {
            //        await context.Response.WriteAsync("second middle ware");
            //    });

            //    endpoints.MapGet("/secondsecond", async context =>
            //    {
            //        await context.Response.WriteAsync("second endpoint though in the second middleware");
            //    });
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("Request 1");
            //    await next();
            //    logger.LogInformation("Request 2");
            //});

            //app.Run(async context => 
            //{ 
            //    throw new Exception("Some errors occured while loading page");
            //    await context.Response.WriteAsync("Hellp");
            //});
           
        }
    }
}
