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
            List<Entry> entries;
            rep = new RepEntryDB();
            rep.Open();
            entries = rep.allEntries();
            rep.Close();
            return View(entries);
        }

        [HttpPost]
        public ActionResult newEntry(Entry newEntryFromForm)
        {

            return View();
        }

        public ActionResult newEntry()
        {
            return View();
        }
    }
}