using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Asp.Net_MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 网站初始化动作
        /// </summary>
        protected void Application_Start()
        {
            //注册区域
            AreaRegistration.RegisterAllAreas();
            //注册全局Filter
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //注册路由
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //注册Bundles，引用JS，CSS需要的组件
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// 只要是响应不是200，就能被捕捉到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender,EventArgs e) 
        {
            Exception exception = Server.GetLastError();
            Response.Write("");
            Server.ClearError();
        }
    }
}
