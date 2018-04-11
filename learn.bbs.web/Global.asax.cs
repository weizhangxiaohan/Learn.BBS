using learn.bbs.utility;
using learn.bbs.web.Filters;
using Learn.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace learn.bbs.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LogError();
        }

        private void LogError()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < 100; i++)
                        {
                            if (BbsErrorHandlerAttribute.MyExceptionQueue.Count > 0)
                            {
                                Exception ex = BbsErrorHandlerAttribute.MyExceptionQueue.Dequeue();
                                builder.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                builder.Append("\r\n");
                                builder.Append(ex.ToString());
                                builder.Append("\r\n");
                                builder.Append("---------------------------------------------------------");
                                builder.Append("\r\n");
                            }
                        }

                        LogHelper.LogToFile(builder.ToString(),LogType.Exception);
                        builder.Clear();

                        Thread.Sleep(3000);
                    }
                }
                catch ( Exception ex)
                {
                    string text = "\r\n" + "发生异常，后台日志线程已退出：" + "\r\n" + ex.ToString() + "\r\n";
                    File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\ThreadLog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", text , System.Text.Encoding.UTF8);
                }
 
            });
        }
    }
}
