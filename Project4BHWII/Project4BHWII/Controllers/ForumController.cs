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
            UserLogin user = Session["loggedinUser"] as UserLogin;
            if(user == null)
            {
                user.Username = "Gast";
            }
            rep = new RepEntryDB();
            rep.Open();
            rep.Insert(newEntryFromForm, user.Username);
            rep.Close();
            return View();
        }

        public ActionResult newEntry()
        {

            return View();
        }
    }
}