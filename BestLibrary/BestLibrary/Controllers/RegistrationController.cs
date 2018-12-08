using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibBusinessLayer.BIL.Interfaces;
using Microsoft.AspNet.Identity.Owin;

namespace BestLibrary.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}