﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Module.Core.Middlewares
{
    public class AwesomeStaticFilesRegister : BaseMiddleware<IApplicationBuilder>
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
