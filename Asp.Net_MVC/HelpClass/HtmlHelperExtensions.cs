using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MVC.HelpClass
{
    /// <summary>
    /// 扩展HtmlHelp帮助类
    /// </summary>
    public static class HtmlHelperExtensions
    {
        public static ListGroup ListGroup(this HtmlHelper htmlHelper)
        {
            return new ListGroup();
        }
    }
    /// <summary>
    /// HtmlHelp扩展方法
    /// </summary>
    public class ListGroup
    {
        public MvcHtmlString Info<T>(List<T> data, Func<T, string> getName)
        {
            return Show(data, getName, "list-group-item-info");
        }

        public MvcHtmlString Warning<T>(List<T> data, Func<T, string> getName)
        {
            return Show(data, getName, "list-group-item-warning");
        }

        public MvcHtmlString Danger<T>(List<T> data, Func<T, string> getName)
        {
            return Show(data, getName, "list-group-item-danger");
        }

        public MvcHtmlString Show<T>(List<T> data, Func<T, string> getName, string style)
        {
            var ulBuilder = new TagBuilder("ul");
            ulBuilder.AddCssClass("list-group");
            foreach (T item in data)
            {
                var liBuilder = new TagBuilder("li");
                liBuilder.AddCssClass("list-group-item");
                liBuilder.AddCssClass(style);
                liBuilder.SetInnerText(getName(item));
                ulBuilder.InnerHtml += liBuilder.ToString();
            }
            return new MvcHtmlString(ulBuilder.ToString());
        }
    }
}