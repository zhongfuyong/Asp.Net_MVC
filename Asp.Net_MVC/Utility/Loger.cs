using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Asp.Net_MVC.Utility
{
    public class Loger
    {
        private readonly ILog loger = null;
        static Loger()
        {
            XmlConfigurator.Configure(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CfgFile/log4net.config")));
            ILog log = LogManager.GetLogger(typeof(Loger));
            log.Info("xxx");
        }
        public Loger(Type type)
        {
            loger = LogManager.GetLogger(type);
        }
        public void Error(string msg = "", Exception ex = null)
        {
            Console.WriteLine(msg);
            loger.Error(msg, ex);
        }
    }
}