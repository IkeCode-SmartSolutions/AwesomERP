using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;

namespace Awe.Mvc.Core.Middlewares
{
    public class AweStaticFilesRegister : AweBaseMiddleware<IApplicationBuilder>
    {
        private IApplicationBuilder _app;

        private AweStaticFilesRegister(IApplicationBuilder app, string folderPath)
            : base(folderPath)
        {
            _app = app;
        }

        public static AweStaticFilesRegister CreateInstance(IApplicationBuilder app, string folderPath)
        {
            return new AweStaticFilesRegister(app, folderPath);
        }

        public override IApplicationBuilder Invoke<T>()
        {
            var providers = new List<IFileProvider>();

            base.CheckIntegrity<T>(out providers);
            
            if (providers.Count > 0)
                _app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = new CompositeFileProvider(providers)
                });

            return ReturnObj;
        }
    }
}
