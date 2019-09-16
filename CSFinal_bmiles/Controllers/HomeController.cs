﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSFinal_bmiles.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hi My name is Benjamin Miles!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact ME!";

            return View();
        }
    }
}