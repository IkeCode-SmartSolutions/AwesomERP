using Awe.Module.Core;
using Awe.Mvc.Core.TagHelpers;
using Awe.Remark.Theme.TagHelpers;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: DefaultNamespace("Awe.Remark.Theme")]
namespace Awe.Remark.Theme
{
    public class ThemeDef : IAweTheme
    {
        private readonly IServiceCollection _services;
        public ThemeDef(IServiceCollection services)
        {
            _services = services;
        }

        public string Description { get { return "Remark theme description"; } }

        public string Name { get { return "Remark"; } }

        public int? Order
        {
            get
            {
                return 1;
            }
        }

        public void RegisterServices()
        {
            _services.AddTransient<IAweOverrideTagHelper<ButtonTagHelper>, RemarkButtonTagHelper>();
        }
    }
}
