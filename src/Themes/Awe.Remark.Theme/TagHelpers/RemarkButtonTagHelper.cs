using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Awe.Mvc.Core.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement("bootstrap-button")]
    public class RemarkButtonTagHelper : TagHelper, IAweOverrideTagHelper<ButtonTagHelper>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider">Injected IServiceProvider</param>
        public RemarkButtonTagHelper(IServiceProvider serviceProvider) 
            : base()
        {
        }

        /// <summary>
        /// Custom implementation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public async Task CustomProcessAsync(ButtonTagHelper baseClassInstance, TagHelperContext context, TagHelperOutput output)
        {
            string str1 = baseClassInstance.ButtonValue.Length <= 0 ? (await output.GetChildContentAsync()).GetContent() : baseClassInstance.ButtonValue;
            string[] array1 = new string[3]
            {
                "a",
                "button",
                "input"
            };
            string[] array2 = new string[3]
            {
                "button",
                "submit",
                "reset"
            };
            string[] array3 = new string[7]
            {
                "default",
                "primary",
                "success",
                "info",
                "warning",
                "danger",
                "link"
            };
            string[] strArray = new string[4]
            {
                "default",
                "large",
                "small",
                "extrasmall"
            };
            string str2 = "";
            if (Array.IndexOf<string>(array1, baseClassInstance.ButtonElement) == -1)
                throw new ArgumentException("Invalid element! Please, use one of the following HTML elements - 'a', 'button' or 'input'");
            if (Array.IndexOf<string>(array2, baseClassInstance.ButtonType) == -1)
                throw new ArgumentException("Invalid button type! Please, use one of the following types - 'button', 'submit' or 'reset'");
            if (Array.IndexOf<string>(array3, baseClassInstance.ButtonOption) == -1)
                throw new ArgumentException("Invalid button option! Please, use one of the following options - 'default', 'primary', 'success', 'info', 'warning', 'danger' or 'link'");
            string str3 = "btn-" + baseClassInstance.ButtonOption;
            if (baseClassInstance.ButtonDisabled)
                str2 = !(baseClassInstance.ButtonElement == "a") ? "disabled='disabled'" : "disabled";
            string str4;
            if (baseClassInstance.ButtonElement == "a")
                str4 = string.Format("<a href='{0}' target='{1}' role='{2}' class='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'>{7}</a>", (object)baseClassInstance.ButtonLink, (object)baseClassInstance.ButtonTarget, (object)baseClassInstance.ButtonType, (object)baseClassInstance.ButtonClass, (object)baseClassInstance.ButtonId, (object)baseClassInstance.ButtonAutocomplete, (object)baseClassInstance.ButtonLoadingText, (object)str1);
            else if (baseClassInstance.ButtonElement == "input")
                str4 = string.Format("<input type='{0}' class='{1}' {2} value='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'/>", (object)baseClassInstance.ButtonType, (object)baseClassInstance.ButtonClass, (object)str2, (object)str1, (object)baseClassInstance.ButtonId, (object)baseClassInstance.ButtonAutocomplete, (object)baseClassInstance.ButtonLoadingText);
            else
                str4 = string.Format("<button data-awe='CUSTOM' type='{0}' class='{1}' {2}  id='{3}' autocomplete='{4}' data-loading-text='{5}'>CUSTOM</button>", (object)baseClassInstance.ButtonType, (object)baseClassInstance.ButtonClass, (object)str2, (object)baseClassInstance.ButtonId, (object)baseClassInstance.ButtonAutocomplete, (object)baseClassInstance.ButtonLoadingText, (object)str1);
            output.Content.AppendHtml(str4);

            return;
        }
    }
}
