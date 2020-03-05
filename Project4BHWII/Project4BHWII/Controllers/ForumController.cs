using Project4BHWII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4BHWII.Controllers
{
    public class ForumController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult newEntry(newEntry newEntryFromForm)
        {
            return View();
        }
    }
}