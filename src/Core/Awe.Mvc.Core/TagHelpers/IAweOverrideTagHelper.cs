using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Awe.Mvc.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public interface IAweOverrideTagHelper<TBaseClass> : IAweTagHelper<TBaseClass>
        where TBaseClass : TagHelper
    {
        void CustomProcess(TBaseClass baseClassInstance, TagBuilder builder, TagHelperContext context, TagHelperOutput output);
    }
}
