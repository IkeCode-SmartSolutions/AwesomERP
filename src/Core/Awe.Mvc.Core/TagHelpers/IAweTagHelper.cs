using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Awe.Mvc.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TBaseClass"></typeparam>
    public interface IAweTagHelper<TBaseClass>
        where TBaseClass : TagHelper
    {
        
    }
}
