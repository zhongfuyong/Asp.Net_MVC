using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MVC.Controllers
{
    public class SubmitController : Controller
    {
        // GET: Submit
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 提交数据
        /// </summary>
        /// <param name="formCol"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string formCol)
        {
            ViewBag.FormValue = Request["username"];
            HttpContext.Session["Value"] = Request["username"];
            return base.Redirect("/Home/ChildAction");
        }
        /// <summary>
        /// 登出清除Cookie、Session
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogOut(FormCollection formCol)
        {
            #region 清除Cookie
            HttpCookie httpCookie = HttpContext.Request.Cookies["xxx"];
            if (httpCookie != null)
            {
                httpCookie.Expires = DateTime.Now.AddMinutes(-1);
                HttpContext.Response.Cookies.Add(httpCookie);
            }
            #endregion

            #region Session
            var sessionUser = HttpContext.Session["xxx"];
            if (sessionUser != null && sessionUser is null)
            {

            }
            HttpContext.Session["xxx"] = null;//表示将制定的键的值清空，并释放掉
            HttpContext.Session.Remove("xxx");
            HttpContext.Session.Clear(); //表示将会话中所有的session的键值都清空，但是session还是依然存在
            HttpContext.Session.RemoveAll();
            HttpContext.Session.Abandon();//就是把当前Session对象删除了，下一次就是新的Session了
            #endregion
            return null;
        }


        #region Ajax提交测试
        public ActionResult AjsxSubmit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AjsxSubmit(TestData nvrModel)
        {
            return null;
        }
        #endregion
    }
    /// <summary>
    /// 测试数据
    /// </summary>
    public class TestData
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}