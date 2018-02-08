using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpPost]
        public ActionResult Login()
        {
            return View("index","home");
        }
    }
}