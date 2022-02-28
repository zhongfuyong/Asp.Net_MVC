using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using Asp.Net.Model;
using Newtonsoft.Json;

namespace Asp.Net_MVC.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 第一种手动验证
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult First() 
        {
            return View(new FirstData());
        }
        [HttpPost]
        public ActionResult First(FirstData testData) 
        {
            //ModelState.AddModelError("Gender", "'Gender'是必需字段");
            if (!ModelState.IsValid)
            {
                return View(testData);
            }
            else
            {
                return Content("输入数据通过验证");
            }
        }

        /// <summary>
        ///第二种ValidationAttribute验证
        ///Required【如果属性为null，""，或只包含空白字符，会引发异常】
        ///RegularExpression【正则表达式验证】
        ///Compare【用来检测两个字段是否相等】
        ///MaxLength【最大长度】
        ///MinLength【最小长度】
        ///Range【输入范围】
        ///StringLength【字符串长度】
        ///CustomValidation【执行自定义的验证】例：[CustomValidation(typeof(自定义验证类), "自定义验证方法")]
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Second()
        {
            return View(new SecondData());
        }
        [HttpPost]
        public ActionResult Second(SecondData secondData) 
        {
            ValidationContext context = new ValidationContext(secondData);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(secondData, context, results, true);

            //Debugger.Break();
            return View();
        }

        /// <summary>
        /// 第三种IValidatableObject
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Third()
        {
            return View(new ThirdData());
        }
        [HttpPost]
        public ActionResult Third(ThirdData thirdData)
        {
            ValidationContext context = new ValidationContext(thirdData);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(thirdData, context, results, true);

            //Debugger.Break();
            return View();
        }

        /// <summary>
        /// 第四种IDataErrorInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Fourth()
        {
            return View(new FourthData());
        }
        [HttpPost]
        public ActionResult Fourth(FourthData fourthData)
        {

            return View();
        }
    }


}