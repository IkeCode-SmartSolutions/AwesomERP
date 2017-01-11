using Awe.Module.Core;
using Awe.Mvc.Core.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace Awe.Mvc.Core
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder RegisterModulesStaticFiles(this IApplicationBuilder app, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AweStaticFilesRegister.CreateInstance(app, folderPath);

            instance.Invoke<IAweModule>();
            instance.Invoke<IAweViewComponent>();
            instance.Invoke<IAweTheme>();

            //return app.UseMiddleware<RegisterModules>(app, folderPath);
            return app;
        }

        public static IMvcBuilder RegisterModulesMvc(this IMvcBuilder mvcBuilder, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AweMvcModuleRegister.CreateInstance(mvcBuilder, folderPath);
            instance.Invoke<IAweComponent>();
            
            return mvcBuilder;
        }

        public static IServiceCollection RegisterModulesRazorView(this IServiceCollection services, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AweRazorViewModuleRegister.CreateInstance(services, folderPath);
            instance.Invoke<IAweModule>();
            instance.Invoke<IAweViewComponent>();
            instance.Invoke<IAweTheme>();

            return services;
        }
    }
}
