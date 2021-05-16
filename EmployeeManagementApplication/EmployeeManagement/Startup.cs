using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Business;
using EmployeeManagement.Business.Contract;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Contract;
using EmployeeManagement.Service.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static EmployeeManagement.DataAccess.Connection.MockData;

namespace EmployeeManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt =>
                opt.UseInMemoryDatabase(databaseName: "FakeEmployeeDbContext"),
                ServiceLifetime.Scoped, ServiceLifetime.Scoped);
            services.AddControllersWithViews();

            services.AddTransient<IEmployeeBusinessAccess, EmployeeBusinessAccess>();
            //services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();
            services.AddTransient<IEmployeeDataAccess, MockEmployeeDataAccess>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApiContext>();
            AddTestData(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "comment",
                    pattern: "comment/{action=Index}/{empId}/{id?}",
                    defaults: new { controller = "Comment", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }





    }
}
