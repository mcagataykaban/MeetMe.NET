using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.TagHelpers
{
    public enum AlertType { Info, Success, Danger, Warning, Primary, Secondary, Light, Dark }
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    public class AlertMessageTagHelper : TagHelper
    {
        public AlertType AlertType { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string alertType = AlertType.ToString().ToLowerInvariant();
            output.TagName = "div";
            TagHelperAttribute existingClass;
            output.Attributes.TryGetAttribute("class", out existingClass);
            if (existingClass == null)
            {
                output.Attributes.SetAttribute("class", "alert alert-" + alertType);
            }
            else
            {
                output.Attributes.SetAttribute("class", existingClass.Value + " alert alert-" + alertType);
            }
            //output.Attributes.SetAttribute("class", "alert alert-info");
        }
    }
}
