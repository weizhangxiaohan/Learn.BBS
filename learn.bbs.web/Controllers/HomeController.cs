using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace learn.bbs.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> GetWeather()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("https://api.seniverse.com/v3/weather/now.json?key=abkpwh7ptga65icd&location=深圳&language=zh-Hans&unit=c");            
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}