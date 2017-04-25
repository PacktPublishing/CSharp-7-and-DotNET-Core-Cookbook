using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;

namespace AspNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //env.EnvironmentName = EnvironmentName.Production;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                DefaultFilesOptions options = new DefaultFilesOptions();
                options.DefaultFileNames.Add("friendlyError.html");
                app.UseDefaultFiles(options);

                app.UseExceptionHandler("/friendlyError");                
            }

            app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    //throw new Exception("Error in app.Run()");
            //    await context.Response.WriteAsync($"The date is {DateTime.Now.ToString("dd MMM yyyy")}");                
            //});

            app.UseMvc(FindController);
        }

        private void FindController(IRouteBuilder route)
        {
            //route.MapRoute("Default", "{controller=Error}/{action=Support}");
        }
    }
}
