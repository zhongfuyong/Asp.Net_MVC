using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_MVC.Controllers
{
    public class VerificationController : Controller
    {
        // GET: Verification
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
    public class FirstData
    {
        public string ip { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
    public class SecondData
    {
        [Required(ErrorMessage = "请填写邮箱")]
        [EmailAddress(ErrorMessage = "邮箱格式错误")]
        public string Email
        {
            get;
            set;
        }

        [Required(ErrorMessage = "请填写密码")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "密码最少 6 位，最长 20 位")]
        public string Password
        {
            get;
            set;
        }

        [Range(18, 150, ErrorMessage = "不到 18 岁不能注册，并请填写合适范围的值")]
        public int Age
        {
            get;
            set;
        }
    }
    public class ThirdData : IValidatableObject
    {
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            ThirdData person = validationContext.ObjectInstance as ThirdData;
            if (null == person)
            {
                yield break;
            }
            if (string.IsNullOrEmpty(person.Name))
            {
                yield return new ValidationResult("'Name'是必需字段", new string[] { "Name" });
            }

            if (string.IsNullOrEmpty(person.Sex))
            {
                yield return new ValidationResult("'Gender'是必需字段", new string[] { "Gender" });
            }
            else if (!new string[] { "M", "F" }.Any(g => string.Compare(person.Sex, g, true) == 0))
            {
                yield return new ValidationResult("有效'Gender'必须是'M','F'之一", new string[] { "Gender" });
            }

            if (null == person.Age)
            {
                yield return new ValidationResult("'Age'是必需字段", new string[] { "Age" });
            }
            else if (person.Age > 25 || person.Age < 18)
            {
                yield return new ValidationResult("'Age'必须在18到25周岁之间", new string[] { "Age" });
            }
        }
    }
    public class FourthData : IDataErrorInfo
    {
        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("性别")]
        public string Sex { get; set; }

        [DisplayName("年龄")]
        public int? Age { get; set; }

        [ScaffoldColumn(false)]
        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name":
                        {
                            if (string.IsNullOrEmpty(this.Name))
                            {
                                return "'姓名'是必需字段";
                            }
                            return null;
                        }
                    case "Gender":
                        {
                            if (string.IsNullOrEmpty(this.Sex))
                            {
                                return "'性别'是必需字段";
                            }
                            else if (!new string[] { "M", "F" }.Any(g => string.Compare(this.Sex, g, true) == 0))
                            {
                                return "'性别'必须是'M','F'之一";
                            }
                            return null;
                        }
                    case "Age":
                        {
                            if (null == this.Age)
                            {
                                return "'年龄'是必需字段";
                            }
                            else if (this.Age > 25 || this.Age < 18)
                            {
                                return "'年龄'必须在18到25周岁之间";
                            }
                            return null;
                        }
                    default: return null;

                }
            }
        }
    }
}