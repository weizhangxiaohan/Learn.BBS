using learn.bbs.utility;
using Learn.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace learn.bbs.web.Controllers
{
    public class AccountController : Controller
    {
        private const string KEY_SESSION_LOGIN_VALIDATE_CODE = "LoginValidateCode";

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("login");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string user_name,string password,string loginValidateCode)
        {
            object code = Session[KEY_SESSION_LOGIN_VALIDATE_CODE];
            if (code == null || code.ToString() != loginValidateCode)
            {
                return RedirectToAction("login");
            }           


            if (Authenticate(user_name, password))
            {
                FormsAuthentication.SetAuthCookie(user_name,false);
                return RedirectToAction("index","home");
            }
            return RedirectToAction("login");
        }

        private bool Authenticate(string userName, string password)
        {
            if (userName == "admin" && password == "admin")
            {
                return true;
            }
            if (userName == "a" && password == "a")
            {
                return true;
            }
            if (userName == "b" && password == "b")
            {
                return true;
            }
            if (userName == "c" && password == "c")
            {
                return true;
            }
            return false;
        }



        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        public ActionResult GetValidateCode()
        {
            ValidateCode code = ValidateCodeHelper.GetValidateCode();
            Session[KEY_SESSION_LOGIN_VALIDATE_CODE] = code.Code;
            return File(code.Image,"image/jpeg");
        }
    }
}