using BestLibrary.Models;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace BestLibrary.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller for registration and authentication functionality.
    /// </summary>
    public class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Authenticates as an incoming Login model.
        /// </summary>
        /// <param name="model">Login Model.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                var clientProfileDto = new ClientProfileDto { Email = model.Email, Password = model.Password };
                var claim = await UserService.Authenticate(clientProfileDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("ElectronicSubscriptions", "Library");
                }
            }
            return View(model);
        }

        /// <summary>
        /// Logout and redirect to ~/Account/Login/
        /// </summary>
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user by the incoming model.
        /// </summary>
        /// <param name="model">Register Model.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                var clientProfileDto = new ClientProfileDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                var operationDetails = await UserService.Create(clientProfileDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("ElectronicSubscriptions", "Library");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        /// <summary>
        /// Initial user initialization.
        /// </summary>
        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new ClientProfileDto
            {
                Email = "somemail@mail.ru",
                UserName = "somemail@mail.ru",
                Password = "1234567",
                Name = "Bob Bobo",
                Address = "str. Tratata, h.30",
                Role = "admin",
                
            }, new List<string> { "user", "admin" });
        }
    }
}
