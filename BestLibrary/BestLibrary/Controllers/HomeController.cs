using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibBusinessLayer.BIL.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace BestLibrary.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
