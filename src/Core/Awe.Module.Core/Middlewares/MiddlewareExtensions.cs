using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Module.Core.Middlewares;

namespace Module.Core
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder RegisterModulesStaticFiles(this IApplicationBuilder app, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AwesomeStaticFilesRegister.CreateInstance(app, folderPath);

            instance.Invoke<IBaseModule>();
            instance.Invoke<IBaseViewComponent>();

            //return app.UseMiddleware<RegisterModules>(app, folderPath);
            return app;
        }

        public static IMvcBuilder RegisterModulesMvc(this IMvcBuilder mvcBuilder, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AwesomeMvcModuleRegister.CreateInstance(mvcBuilder, folderPath);
            instance.Invoke<IBaseComponent>();
            
            return mvcBuilder;
        }

        public static IServiceCollection RegisterModulesRazorView(this IServiceCollection services, string folderPath = "")
        {
            if (string.IsNullOrWhiteSpace(folderPath))
                folderPath = PlatformServices.Default.Application.ApplicationBasePath;

            var instance = AwesomeRazorViewModuleRegister.CreateInstance(services, folderPath);
            instance.Invoke<IBaseModule>();
            instance.Invoke<IBaseViewComponent>();

            return services;
        }
    }
}
