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
        /// ��վ��ʼ������
        /// </summary>
        protected void Application_Start()
        {
            //ע������
            AreaRegistration.RegisterAllAreas();
            //ע��ȫ��Filter
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //ע��·��
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ע��Bundles������JS��CSS��Ҫ�����
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        /// ֻҪ����Ӧ����200�����ܱ���׽��
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
