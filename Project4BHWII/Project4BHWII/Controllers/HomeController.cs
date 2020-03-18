using Project4BHWII.Models;
using Project4BHWII.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4BHWII.Controllers
{
    public class HomeController : Controller
    {
        IRepEntry rep;
        public ActionResult Index()
        {
            List<Entry> allEntries;
            rep = new RepEntryDB();
            rep.Open();
            allEntries = rep.allEntries();
            rep.Close();
            return View(allEntries);
        }

        public ActionResult allEntries()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            rep = new RepEntryDB();
            rep.Open();
            rep.Delete(id);
            rep.Close();
            return RedirectToAction("Index");
            
        }

    }
}