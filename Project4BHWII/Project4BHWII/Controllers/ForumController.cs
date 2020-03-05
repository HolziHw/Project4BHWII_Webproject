using Project4BHWII.Models;
using Project4BHWII.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4BHWII.Controllers
{
    public class ForumController : Controller
    {
        IRepEntry rep;
        public ActionResult Index()
        {
            return View();

        }

        public ActionResult allEntries()
        {
            List<newEntry> entries;
            rep = new RepEntryDB();
            rep.Open();
            entries = rep.allEntries();
            rep.Close();
            return View(entries);
        }

        public ActionResult newEntry(newEntry newEntryFromForm)
        {

            return View();
        }
    }
}