using learn.bbs.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Filters
{
    public class BbsErrorHandlerFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            Exception ex = filterContext.Exception;
            LogHelper.LogToFile(ex);
            filterContext.HttpContext.Response.Redirect("/ErrorPages/Error.htm");
        }
    }
}