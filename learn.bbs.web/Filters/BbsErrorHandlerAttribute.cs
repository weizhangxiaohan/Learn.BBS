using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Filters
{
    public class BbsErrorHandlerAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> MyExceptionQueue = new Queue<Exception>();

        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            //接下来就是得加入到队列中进行处理
            MyExceptionQueue.Enqueue(ex);
            //跳转到错误页面
            filterContext.HttpContext.Response.Redirect("/ErrorPages/Error.htm");
        }
    }
}