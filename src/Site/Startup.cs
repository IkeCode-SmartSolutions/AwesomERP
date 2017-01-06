using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Http;
using Module.Core;
using Microsoft.Extensions.PlatformAbstractions;
using AwesomeErp.Core.Reflection;
using Microsoft.AspNetCore.Mvc;
//using Awe.Menu.Service;

namespace Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=.\SQLEXPRESS;Database=AwesomeErp;Trusted_Connection=True;";
            //services.AddDbContext<MenuContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services
                .AddMvc()
                .RegisterModulesMvc();
            
            services.RegisterModulesRazorView();

            //services.AddSingleton<IAweMenuService, AweMenuService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app
                .UseStaticFiles()
                .RegisterModulesStaticFiles();

            var modules = AssemblyTools.LoadAssembliesThatImplements<IBaseModule>(PlatformServices.Default.Application.ApplicationBasePath);

            var menus = new Dictionary<string, List<string>>();

            foreach (var module in modules)
            {
                var controllers = module.GetTypes().Where(q => typeof(Controller).IsAssignableFrom(q));
                foreach (var controller in controllers)
                {
                    var methods = controller.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                    //var filtered = methods.Where(i => i.GetCustomAttribute<MenuAttribute>() != null).ToList();
                    
                    //menus[controller.Name] = filtered.Select(i => i.Name).ToList();

                    //urlHelper.RouteUrl()

                    var a = 1;
                }
            }

            app
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
