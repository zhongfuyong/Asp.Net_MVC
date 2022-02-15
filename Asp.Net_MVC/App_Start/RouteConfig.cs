using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Asp.Net_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
        public static void MyRegisterRoutes(RouteCollection routes)
        {
            //特性路由
            routes.MapMvcAttributeRoutes();
            //忽略资源文件
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //定义路由
            routes.MapRoute(
                //路由名，唯一
                name: "MyRoutesName",
                //路由URL
                url: "{controller}/{action}/{id}",
                //路由默认值
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //命名空间避免二义性
                namespaces: new[] { "MVCDemo.Controllers" },
                //约束
                constraints: new { id = @"^\d*$" }
            ); ;
        }
    }
}
