using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Asp.Net_MVC
{
    //框架内部不是用特性去判断过滤，不是用Attribute，而是用FilterAttribute；
    /// <summary>
    /// 默认
    /// </summary>
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //全局添加过滤器
            //filters.Add(new MyFilter1Attribute());
            //filters.Add(new MyFilter2Attribute());
            //filters.Add(new MyFilter3Attribute());
        }
    }

    /// <summary>
    /// 控制器、视图行为过滤器
    /// </summary>
    public class MyFilter1Attribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行方法前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            #region 网页压缩减小传输信息，加快速度
            //要判断浏览器是否有和服务器同样的压缩规则
            var request = filterContext.HttpContext.Request;
            var response = filterContext.HttpContext.Response;
            //检测支持格式
            string acceptEncoding = request.Headers["Accept-Encoding"];

            if (!string.IsNullOrWhiteSpace(acceptEncoding) && acceptEncoding.ToUpper().Contains("GZIP"))
            {
                //响应头执行类型
                response.AddHeader("Content-Encoding", "gzip");
                response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
            }
            #endregion
        }
        /// <summary>
        /// 执行方法后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
        /// <summary>
        /// 加载视图前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
        /// <summary>
        /// 加载视图后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }

    /// <summary>
    /// 异常处理过滤器
    /// Web.config配置文件中的<system.web>节点下面添加  <customErrors mode="On"></customErrors>
    /// </summary>
    public class MyFilter3Attribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //处理异常
                //如果是访问页面应该展示一个错误页面，报异常信息
                //如果是AJAX请求，就该响应一个json文件数据出去
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            DebugMassage = filterContext.Exception.Message,
                            RetValue = "",
                            PromptMsg = "错误",
                        }
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message),
                    };
                }
                //异常已处理
                filterContext.ExceptionHandled = true;
            }
            //异常已处理
            filterContext.ExceptionHandled = true;
        }
    }

    /// <summary>
    /// 权限过滤器
    /// 在全局中注册过滤器，则所有控制器的所有行为（Action）都会执行这个过滤器。
    /// </summary>
    public class MyFilter2Attribute : AuthorizeAttribute
    {
        public string LogingUrl { get; set; } = null;
        public MyFilter2Attribute(string logingUrl = "~/Home/Index") 
        {
            this.LogingUrl = logingUrl;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            HttpContextBase httpContextBase = filterContext.HttpContext;
            if (filterContext.ActionDescriptor.IsDefined(typeof(MyAllowAnonymousAttribute), true))
            {
                return;
            }
            else if(filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(MyAllowAnonymousAttribute), true))
            {
                return;
            }
            if (httpContextBase.Session["Value"] == null)
            {
                if (httpContextBase.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data=new 
                        {
                            DebugMessage = "登陆过期",
                            RetValue = ""
                        }
                    };
                }
                else
                {
                    httpContextBase.Session["CurrentUrl"] = httpContextBase.Request.Url.AbsoluteUri;
                    filterContext.Result = new RedirectResult(this.LogingUrl);
                }
            }
            else
            {
                return;
            }
        }
    }
    /// <summary>
    /// 过滤localhost 将您重定向的次数过多
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class MyAllowAnonymousAttribute : Attribute
    {
        
    }

    //AuthorizationFilterAttribute

    //RequireHttpsAttribute:Http请求重定向；如果当前请求地址为http://www.baidu.com，会自动重定向到https://www.baidu.com。
    //如果当前请求的HTTP方法并不是GET，RequireHttpsAttribute会直接抛出一个InvalidOperationException异常。

    //ValidateInputAttribute该特性用于标记必须验证其输入的操作方法

    //ValidateAntiForgeryTokenAttribute用于解决一种叫做“跨站请求伪造（CSRF：Cross-Site Request Forgery）”

    //IResourceFilter---.Net6.0
}
