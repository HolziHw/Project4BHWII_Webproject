﻿using System;
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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new User());
            Session["UserData"] = 
        }

        public ActionResult Registration()
        {
            return View();
        }


    }
}