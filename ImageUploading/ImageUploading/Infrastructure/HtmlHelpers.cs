using System.Web.Mvc;
using System.Web.Routing;

namespace AlrawiLtd.Infrastructure
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString ImageActionLink(this HtmlHelper helper , string imagePath , string actionName , string controllerName , object routeValues , object imageAttributes , object linkAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext , helper.RouteCollection);
            var aElementBuilder = new TagBuilder("a"); aElementBuilder.MergeAttributes(new RouteValueDictionary(linkAttributes));
            aElementBuilder.MergeAttribute("href" , urlHelper.Action(actionName , controllerName , routeValues));
            var imgElementBuilder = new TagBuilder("img"); aElementBuilder.MergeAttributes(new RouteValueDictionary(imageAttributes));
            imgElementBuilder.MergeAttribute("src" , imagePath); aElementBuilder.InnerHtml = imgElementBuilder.ToString(TagRenderMode.SelfClosing);
            return new MvcHtmlString(aElementBuilder.ToString(TagRenderMode.Normal));
        }
    }
}