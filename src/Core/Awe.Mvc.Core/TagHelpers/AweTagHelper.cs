using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Awe.Mvc.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public abstract class AweTagHelper<TBaseClass> : TagHelper
        where TBaseClass : TagHelper
    {
        protected readonly IServiceProvider ServiceProvider;

        public AweTagHelper(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public abstract TBaseClass Self { get; }
        public abstract TagBuilder Builder { get; }

        public abstract Task CustomProcessAsync(TagBuilder builder, TagHelperContext context, TagHelperOutput output);
        
        public sealed override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var customImplementation = ServiceProvider.GetService<IAweOverrideTagHelper<TBaseClass>>();
            
            if (customImplementation != null)
            {
                customImplementation.CustomProcess(Self, Builder, context, output);
            }
            else
            {
                await CustomProcessAsync(Builder, context, output);
            }

            await base.ProcessAsync(context, output);
        }
    }
}
