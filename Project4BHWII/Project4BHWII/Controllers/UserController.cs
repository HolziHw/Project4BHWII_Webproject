using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project4BHWII.Models;

namespace Project4BHWII.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View(new User());
        }


        [HttpPost]
        public ActionResult Login(User UserDaten)
        {
            UserDaten.Firstname = "Holzi";
            UserDaten.Username = "Holzi";
            Session["User"] = UserDaten;
            return RedirectToAction("Index","Home");
        }

        public ActionResult Registration()
        {
            return View();
        }


    }
}