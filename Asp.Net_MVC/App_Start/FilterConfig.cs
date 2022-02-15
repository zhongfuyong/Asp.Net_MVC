using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MVC
{
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
        /// 执行Controllers的方法时执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
        /// <summary>
        /// 执行Controllers的方法后执行
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
    /// 权限过滤器
    /// 在全局中注册过滤器，则所有控制器的所有行为（Action）都会执行这个过滤器。
    /// </summary>
    public class MyFilter2Attribute : AuthorizeAttribute
    {
        /// <summary>
        /// 授权过滤器
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Write("OnAuthorization");
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
            filterContext.HttpContext.Response.Write("aaa");
        }
    }
}
