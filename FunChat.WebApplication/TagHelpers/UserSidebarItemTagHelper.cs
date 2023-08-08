using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FunChat.WebApplication.TagHelpers
{
    [HtmlTargetElement("UserSidebarItem")]
    public class UserSidebarItemTagHelper : TagHelper
    {
        public string RequestedPath { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var itemUrl = GetItemUrl(Controller, Action, Area);
            output.TagName = "a";
            output.Attributes.SetAttribute("href", itemUrl);
            output.Attributes.SetAttribute("class", "list-group-item list-group-item-action");
            if (RequestedPath == itemUrl)
            {
                output.Attributes.SetAttribute("aria-current", "true");
                output.Attributes.SetAttribute("class", "list-group-item list-group-item-action active");


            }

            var innerText = output.GetChildContentAsync().Result.GetContent();

            output.Content.SetContent(innerText);

        }

        private static string GetItemUrl(string controller, string action, string area = null)
        {
            StringBuilder itemUrl = new StringBuilder("/");
            if (!string.IsNullOrEmpty(area))
            {
                itemUrl.Append(area);
                itemUrl.Append("/");

            }
            itemUrl.Append(controller);
            itemUrl.Append("/");
            itemUrl.Append(action);

            return itemUrl.ToString();
        }


    }
}
