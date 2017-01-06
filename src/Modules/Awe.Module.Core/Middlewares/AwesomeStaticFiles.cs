using AwesomeErp.Core.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Module.Core.Middlewares
{
    public class AwesomeStaticFilesRegister : BaseMiddleware
    {
        private IApplicationBuilder _app;

        private AwesomeStaticFilesRegister(IApplicationBuilder app, string folderPath)
            : base(folderPath)
        {
            _app = app;
        }

        public static AwesomeStaticFilesRegister CreateInstance(IApplicationBuilder app, string folderPath)
        {
            return new AwesomeStaticFilesRegister(app, folderPath);
        }

        public void Invoke<T>()
        {
            var providers = new List<IFileProvider>();

            base.CheckIntegrity<T>(out providers);
            
            if (providers.Count > 0)
                _app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new CompositeFileProvider(providers)
                });
        }
    }
}
