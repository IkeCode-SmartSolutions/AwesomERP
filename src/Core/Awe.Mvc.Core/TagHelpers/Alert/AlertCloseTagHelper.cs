using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.TagHelpers
{
  [HtmlTargetElement("bootstrap-alert-close")]
  public class AlertCloseTagHelper : TagHelper
  {
    [HtmlAttributeName("class")]
    public string AlertCloseClass { get; set; }

    public AlertCloseTagHelper()
    {
      
    }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
      TagHelperContent childContentAsync = await output.GetChildContentAsync();
      output.Content.AppendHtml(childContentAsync.GetContent());
      output.Attributes.SetAttribute("type", (object) "button");
      output.Attributes.SetAttribute("class", (object) ("close " + this.AlertCloseClass));
      output.Attributes.SetAttribute("data-dismiss", (object) "alert");
      output.Attributes.SetAttribute("aria-label", (object) "Close");
      // ISSUE: reference to a compiler-generated method
      
    }
  }
}
