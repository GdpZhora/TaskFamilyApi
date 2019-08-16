using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFamilyWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace TaskFamilyWeb
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ITodoRepository, FakeTodoRepository>();
            services.AddTransient<IBudget, FakeBudget>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            /* app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: null,
                template: "",
                defaults: new { Controller = "Main", action = "index" });

                routes.MapRoute(
                name: null,
                template: "/index",
                defaults: new { Controller = "Main", action = "index" });

                routes.MapRoute(
                name: null,
                template: "/todo",
                defaults: new { Controller = "Todo", action = "List" });

                routes.MapRoute(
                name: "budget",
                template: "/budget",
                defaults: new { Controller = "Budget", action = "List" });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });*/
        }
    }
}
