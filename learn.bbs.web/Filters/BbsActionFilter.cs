using learn.bbs.utility;
using Learn.Log;
using Learn.Log.LogEntry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Filters
{
    public class BbsActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendFormat("在{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            builder.AppendLine();
            //builder.AppendFormat("{0}访问了{1}",filterContext.HttpContext.User.Identity.Name,filterContext.HttpContext.Request.Url);
            builder.AppendLine();
            builder.AppendFormat("当前线程ID：{0}",Thread.CurrentThread.ManagedThreadId + Thread.CurrentThread.Name);
            builder.AppendLine();
            builder.Append("--------------------------------------------------------");
            builder.AppendLine();
            LogHelper.LogToFile(builder.ToString());

            OperationLogInfo logInfo = new OperationLogInfo();
            logInfo.Creator = filterContext.HttpContext.User.Identity.Name;
            logInfo.CreateTime = DateTime.Now;
            logInfo.TargetUrl = filterContext.HttpContext.Request.Url.OriginalString;
            LogHelper.LogToFile(logInfo);
        }
    }
}