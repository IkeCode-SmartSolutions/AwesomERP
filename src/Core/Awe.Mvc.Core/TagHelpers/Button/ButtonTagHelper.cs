using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Awe.Mvc.Core.TagHelpers
{
    [HtmlTargetElement("bootstrap-button")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("element")]
        public string ButtonElement { get; set; }

        [HtmlAttributeName("id")]
        public string ButtonId { get; set; }

        [HtmlAttributeName("autocomplete")]
        public string ButtonAutocomplete { get; set; }

        [HtmlAttributeName("loading-text")]
        public string ButtonLoadingText { get; set; }

        [HtmlAttributeName("class")]
        public string ButtonClass { get; set; }

        [HtmlAttributeName("type")]
        public string ButtonType { get; set; }

        [HtmlAttributeName("option")]
        public string ButtonOption { get; set; }

        [HtmlAttributeName("size")]
        public string ButtonSize { get; set; }

        [HtmlAttributeName("active")]
        public bool ButtonActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool ButtonDisabled { get; set; }

        [HtmlAttributeName("block")]
        public bool ButtonBlock { get; set; }

        [HtmlAttributeName("value")]
        public string ButtonValue { get; set; }

        [HtmlAttributeName("link")]
        public string ButtonLink { get; set; }

        [HtmlAttributeName("target")]
        public string ButtonTarget { get; set; }

        public ButtonTagHelper() : base()
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string str1 = ButtonValue.Length <= 0 ? (await output.GetChildContentAsync()).GetContent() : ButtonValue;
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
            if (Array.IndexOf<string>(array1, ButtonElement) == -1)
                throw new ArgumentException("Invalid element! Please, use one of the following HTML elements - 'a', 'button' or 'input'");
            if (Array.IndexOf<string>(array2, ButtonType) == -1)
                throw new ArgumentException("Invalid button type! Please, use one of the following types - 'button', 'submit' or 'reset'");
            if (Array.IndexOf<string>(array3, ButtonOption) == -1)
                throw new ArgumentException("Invalid button option! Please, use one of the following options - 'default', 'primary', 'success', 'info', 'warning', 'danger' or 'link'");
            string str3 = "btn-" + ButtonOption;
            if (ButtonDisabled)
                str2 = !(ButtonElement == "a") ? "disabled='disabled'" : "disabled";
            string str4;
            if (ButtonElement == "a")
                str4 = string.Format("<a href='{0}' target='{1}' role='{2}' class='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'>{7}</a>", (object)ButtonLink, (object)ButtonTarget, (object)ButtonType, (object)ButtonClass, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText, (object)str1);
            else if (ButtonElement == "input")
                str4 = string.Format("<input type='{0}' class='{1}' {2} value='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'/>", (object)ButtonType, (object)ButtonClass, (object)str2, (object)str1, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText);
            else
                str4 = string.Format("<button type='{0}' class='{1}' {2}  id='{3}' autocomplete='{4}' data-loading-text='{5}'>{6}</button>", (object)ButtonType, (object)ButtonClass, (object)str2, (object)ButtonId, (object)ButtonAutocomplete, (object)ButtonLoadingText, (object)str1);
            output.Content.AppendHtml(str4);
        }
    }
}
