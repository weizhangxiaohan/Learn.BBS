using learn.bbs.web.Filters;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new BbsErrorHandlerFilter());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new BbsActionFilter());
        }
    }
}
