using AwesomeErp.Core.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Middlewares
{
    public class AwesomeRazorViewModuleRegister : BaseMiddleware
    {
        private IServiceCollection _serviceCollection;

        private AwesomeRazorViewModuleRegister(IServiceCollection serviceCollection, string folderPath)
            : base(folderPath)
        {
            _serviceCollection = serviceCollection;
        }

        public static AwesomeRazorViewModuleRegister CreateInstance(IServiceCollection serviceCollection, string folderPath)
        {
            return new AwesomeRazorViewModuleRegister(serviceCollection, folderPath);
        }

        public void Invoke<T>()
        {
            var providers = new List<IFileProvider>();

            base.CheckIntegrity<T>(out providers);

            //Add the file provider to the Razor view engine
            _serviceCollection.Configure<RazorViewEngineOptions>(options =>
            {
                foreach (var provider in providers)
                {
                    options.FileProviders.Add(provider);
                }
            });
        }
    }
}
