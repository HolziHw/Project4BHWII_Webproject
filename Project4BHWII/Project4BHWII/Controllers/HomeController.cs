using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4BHWII.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.FileName = "/Media/Pictures/Eu4banner_2.jfif";
            return View();
        }

        public ActionResult newEntry()
        {
            return View();
        }

    }
}