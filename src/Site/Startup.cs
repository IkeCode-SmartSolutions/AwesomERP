using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Awe.Menu.Service;
using Awe.Mvc.Core;
using Microsoft.AspNetCore.Routing;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using Awe.Mvc.Core.Multitenancy;

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

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            services.Configure<AweMultitenancyOptions>(Configuration.GetSection("Multitenancy"));
            services.AddDefaultCachedMultitenancy();

            services
                .AddMvc()
                .RegisterModulesMvc();

            services
                .RegisterModulesRazorView()
                .RegisterThemes();

            builder.RegisterType<AweMenuService>().As<IAweMenuService>().SingleInstance();
            //services.AddSingleton<IAweMenuService, AweMenuService>();

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            var serviceProvider = new AutofacServiceProvider(this.ApplicationContainer);

            return serviceProvider;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
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

            app
                .UseDefaultMultitenancy()
                .RegisterMenus();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
