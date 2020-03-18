using Project4BHWII.Models;
using Project4BHWII.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4BHWII.Controllers
{
    public class AdminController : Controller
    {
        IRepUser rep;
        // GET: Admin
        public ActionResult Index()
        {
            rep = new RepUserDB();
            List<User> allUser = new List<User>();
            rep.Open();
            allUser = rep.GetAllUser();
            rep.Close();
            return View(allUser);
        }
    }
}