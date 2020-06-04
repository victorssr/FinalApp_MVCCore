using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing;
using System;

namespace VSDev.MVC.Extensions.TagHelpers
{
    [HtmlTargetElement("*", Attributes = "supress-by-action")]
    public class SupressElementByActionTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SupressElementByActionTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("supress-by-action")]
        public string ActionName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (output == null) throw new ArgumentNullException(nameof(output));

            var currentAction = _httpContextAccessor.HttpContext.GetRouteData().Values["action"].ToString();
            if (ActionName.Contains(currentAction)) return;

            output.SuppressOutput();
        }
    }
}
