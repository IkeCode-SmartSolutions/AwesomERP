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

        protected readonly IAweOverrideTagHelper<TBaseClass> Overrider;

        public AweTagHelper(IServiceProvider serviceProvider, IAweOverrideTagHelper<TBaseClass> overrider)
        {
            ServiceProvider = serviceProvider;
            Overrider = overrider;
        }

        public abstract TBaseClass Self { get; }
        public abstract TagBuilder Builder { get; }

        public abstract Task ProcessAsync(TagBuilder builder, TagHelperContext context, TagHelperOutput output);
        
        public sealed override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var customImplementations = ServiceProvider.GetServices<IAweOverrideTagHelper<TBaseClass>>();

            await ProcessAsync(Builder, context, output);

            if (customImplementations != null & customImplementations.Count() > 0)
            {
                foreach (var impl in customImplementations)
                {
                    impl.CustomProcess(Self, Builder, context, output);
                }
            }
            
            await base.ProcessAsync(context, output);
        }
    }
}
