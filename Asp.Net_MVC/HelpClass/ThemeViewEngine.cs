using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MVC.HelpClass
{
    /// <summary>
    /// RazorViewEngine实现切换主题--重写视图引擎
    /// </summary>
    public class ThemeViewEngine: RazorViewEngine
    {
        public ThemeViewEngine(string theme)
        {

            ViewLocationFormats = new[]
            {
            "~/Views/Themes/" + theme + "/{1}/{0}.cshtml",
            "~/Views/Themes/" + theme + "/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = new[]
            {
            "~/Views/Themes/" + theme + "/{1}/{0}.cshtml",
            "~/Views/Themes/" + theme + "/Shared/{0}.cshtml"
            };

            AreaViewLocationFormats = new[]
            {
            "~Areas/{2}/Views/Themes/" + theme + "/{1}/{0}.cshtml",
            "~Areas/{2}/Views/Themes/" + theme + "/Shared/{0}.cshtml"
            };

            AreaPartialViewLocationFormats = new[]
            {
            "~Areas/{2}/Views/Themes/" + theme + "/{1}/{0}.cshtml",
            "~Areas/{2}/Views/Themes/" + theme + "/Shared/{0}.cshtml"
            };
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var ck = controllerContext.HttpContext.Request.Cookies.Get("p_lang");
            string lg = "";
            if (ck != null)
            {
                lg = ck.Value;
                if (lg.ToLower() == "en")
                {
                    viewPath = viewPath.Replace("Views", "Views/en");
                }
            }
            return base.CreateView(controllerContext, viewPath, masterPath);
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var ck = controllerContext.HttpContext.Request.Cookies.Get("p_lang");
            string lg = "";
            if (ck != null)
            {
                lg = ck.Value;
                if (lg.ToLower() == "en")
                {
                    partialPath = partialPath.Replace("Views", "Views/en");
                }
            }
            return base.CreatePartialView(controllerContext, partialPath);
        }
    }
}