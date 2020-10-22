using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Infrastructure.Interfaces;
using Core.Infrastructure.Services;
using Core_1.Infrastructure;
using Core_1.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Core_1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddRazorPages();
            services.AddSingleton<IEmployeeService, InMemoryEmployeesServise>();
            services.AddSingleton<IClientService, InMemoryClientServise>();
            services.AddSingleton<IProductService, InMemoryProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
              
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            // app.UseCookiePolicy();

            app.UseRouting();
            // app.UseRequestLocalization();
            // app.UseCors();

            //app.UseAuthentication();
            //app.UseAuthorization();
            // app.UseSession();
            // app.UseResponseCaching();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
//                endpoints.MapGet("/", async context =>
//               {
//                    await context.Response.WriteAsync("hello default");
 //               });
            });
        }
    }
}
