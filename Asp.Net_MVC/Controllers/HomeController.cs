using Asp.Net.Interface;
using Asp.Net.Model;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using Unity;

namespace Asp.Net_MVC.Controllers
{
    //[MyFilter2Attribute]
    /// <summary>
    /// Controller-初始化时扫描项目继承Controller的类，可以做出插件式开发和热插拔
    /// </summary>
    public class HomeController : Controller
    {
        //[MyAllowAnonymousAttribute]
        public ActionResult Index()
        {
            #region IOC
            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfgFile\\Unity.Config");
            //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection(UnityConfigurationSection.SectionName);
            //IUnityContainer container = new UnityContainer();
            //section.Configure(container, "aaaa");

            //ISubInterface subInterface = container.Resolve<ISubInterface>();
            #endregion

            return View();
        }

        /// <summary>
        /// 内嵌模板Action 只能被子访问，不能独立访问
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        [MyFilter2Attribute]
        public ViewResult ChildAction(string name) 
        {
            base.ViewBag.Name = name;
            return View();
        }
        /// <summary>
        /// 自定义扩展组件
        /// </summary>
        /// <returns></returns>
        public static MvcHtmlString Br() 
        {
            TagBuilder tagBuilder = new TagBuilder("br");
            tagBuilder.MergeAttribute("src","");
            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.SelfClosing));
        }
    }
}