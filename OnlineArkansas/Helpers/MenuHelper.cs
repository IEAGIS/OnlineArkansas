using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineArkansas.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString MenuItem(
            this HtmlHelper htmlHelper,
            string text,
            string action,
            string controller)
            {
                var li = new TagBuilder("li");
                var href = new TagBuilder("a");
                var span = new TagBuilder("span");
                var url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

                span.SetInnerText(text);
                span.ToString(TagRenderMode.EndTag);
                
                var routeData = htmlHelper.ViewContext.RouteData;
                var currentAction = routeData.GetRequiredString("action");
                var currentController = routeData.GetRequiredString("controller");
                
                if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
                {
                    href.AddCssClass("active");
                }
                href.MergeAttribute("href", url.Action(action), true);
                href.InnerHtml = span.ToString();                
                href.ToString(TagRenderMode.EndTag);
                li.InnerHtml = href.ToString();
                return MvcHtmlString.Create(li.ToString());
            }

             public static MvcHtmlString AbsolutePath(
                this HtmlHelper htmlHelper,
                string text,
                string action,
                string controller)
            {
                var href = new TagBuilder("a");
                var url = new UrlHelper(htmlHelper.ViewContext.RequestContext);

                href.MergeAttribute("href", url.Action(action), true);
                href.SetInnerText(text);
                href.ToString(TagRenderMode.EndTag);
                return MvcHtmlString.Create(href.ToString());

            }
    }
}