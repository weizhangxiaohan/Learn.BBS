using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using learn.bbs.utility;

namespace learn.bbs.bl.HttpModule
{
    public class LearnAuthModule : IHttpModule
    {
        private static string _authCookieName = "--LearnAuthCookie--";
        private static string _redirectLoginUrl = "/login.html";
        public static string _desKey = "asekey32w";

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += this.Application_BeginRequest;
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            HttpCookie authCookie = context.Request.Cookies[_authCookieName];

            if (authCookie == null)
            {
                context.Response.Redirect(_redirectLoginUrl);
            }

            string cooikeValue = authCookie.Value;
            cooikeValue = DESEncrypt.Decrypt(cooikeValue, _desKey);

            
        }

        private bool IsAuth()
        {
            bool result = false;
            return result;
        }
    }
}
