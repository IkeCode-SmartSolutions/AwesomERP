using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;

namespace Awe.Mvc.Core.Middlewares
{
    public class AweRazorViewModuleRegister : AweBaseMiddleware<IServiceCollection>
    {
        private IServiceCollection _serviceCollection;

        private AweRazorViewModuleRegister(IServiceCollection serviceCollection, string folderPath)
            : base(folderPath)
        {
            _serviceCollection = serviceCollection;
        }

        public static AweRazorViewModuleRegister CreateInstance(IServiceCollection serviceCollection, string folderPath)
        {
            return new AweRazorViewModuleRegister(serviceCollection, folderPath);
        }

        public override IServiceCollection Invoke<T>()
        {
            var providers = new List<IFileProvider>();
            base.CheckIntegrity<T>(out providers);

            if (providers.Count > 0)
            {
                //Add the file provider to the Razor view engine
                _serviceCollection.Configure<RazorViewEngineOptions>(options =>
                {
                    foreach (var provider in providers)
                    {
                        options.FileProviders.Add(provider);
                    }
                });
            }

            return ReturnObj;
        }
    }
}
