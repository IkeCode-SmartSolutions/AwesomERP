using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

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

        public abstract Task CustomProcessAsync(TagHelperContext context, TagHelperOutput output);

        public sealed override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var customImplementation = ServiceProvider.GetService<IAweOverrideTagHelper<TBaseClass>>();

            if (customImplementation != null)
            {
                await customImplementation.CustomProcessAsync(Self, context, output);
            }
            else
            {
                await CustomProcessAsync(context, output);
            }
        }
    }
}
