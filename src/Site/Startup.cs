using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Microsoft.Extensions.PlatformAbstractions;
using Awe.Core.Reflection;
using Microsoft.AspNetCore.Mvc;
using Awe.Menu.Service;
using Awe.Mvc.Core.TagHelpers;
using Awe.Mvc.Core;
using Awe.Module.Core;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;

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
        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //var connection = @"Server=.\SQLEXPRESS;Database=AwesomeErp;Trusted_Connection=True;";
            //services.AddDbContext<MenuContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services
                .AddMvc()
                .RegisterModulesMvc();
            
            services.RegisterModulesRazorView();

            services.AddTransient<IAweOverrideTagHelper<ButtonTagHelper>, RemarkButtonTagHelper>();

            services.AddSingleton<IAweMenuService, AweMenuService>();



            var builder = new ContainerBuilder();

            builder.Populate(services);

            builder.RegisterType<RemarkButtonTagHelper>().As<IAweOverrideTagHelper<ButtonTagHelper>>();

            builder.RegisterType<AweMenuService>().As<IAweMenuService>();

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env, 
                              ILoggerFactory loggerFactory,
                              IApplicationLifetime appLifetime)
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

            var modules = AssemblyTools.LoadAssembliesThatImplements<IAweModule>(PlatformServices.Default.Application.ApplicationBasePath);

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

                    //var a = 1;
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
