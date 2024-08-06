using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_HM_1.Models;

namespace WebMVC_HM_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SaveData model = new SaveData
            {
                TempDataValue = TempData["TempDataValue"] as string,
                CookiesValue = Request.Cookies["CookiesValue"]?.Value,
                SessionValue = Session["SessionValue"] as string
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SaveTempData()
        {
            TempData["TempDataValue"] = Request.Form["TempDataValue"];
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SaveCookies()
        {
            HttpCookie cookie = new HttpCookie("CookiesValue")
            {
                Value = Request.Form["CookiesValue"],
                Expires = DateTime.Now.AddDays(1)
            };
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SaveSession()
        {
            Session["SessionValue"] = Request.Form["SessionValue"];
            return RedirectToAction("Index");
        }
    }
}