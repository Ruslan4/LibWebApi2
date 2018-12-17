using BestLibrary.Models;
using BestLibrary.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BestLibrary.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller of work with library information system.
    /// </summary>
    [Authorize]
    public class LibraryController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        /// <summary>
        /// Return  Electronic Subscriptions  lib.
        /// </summary>
        [HttpGet]
        public ActionResult ElectronicSubscriptions()
        {
            ClientProfileDto clientProfileDto = new ClientProfileDto
            {
                Id = User.Identity.GetUserId(),
                Email = User.Identity.Name
            };

            return View(clientProfileDto);
        }

        /// <summary>
        /// Get All Books in  lib.
        /// </summary>
        // GET: Library
        [Authorize]
        public ActionResult GetAllBooks()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Book/");
            response.EnsureSuccessStatusCode();
            List<BookViewModel> products = response.Content.ReadAsAsync<List<BookViewModel>>().Result;
            ViewBag.Title = "All books";
            return View(products);
        }

        /// <summary>
        /// Edit Book in lib.
        /// </summary>
        /// <param name="id">Book ID </param>
        //[HttpGet]  
        public ActionResult EditBook(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Book/?id=" + id);
            response.EnsureSuccessStatusCode();
            BookViewModel products = response.Content.ReadAsAsync<BookViewModel>().Result;
            ViewBag.Title = "All Books";
            return View(products);
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        /// <summary>
        ///  Create new Book in lib.
        /// </summary>
        /// <param name="book">Book View Model </param>
        [HttpPost]
        public ActionResult CreateBook(Models.BookViewModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Book/AddBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }

        /// <summary>
        ///  Get detailed information about the book.
        /// </summary>
        /// <param name="id">Book ID </param>
        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Book/GetBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.BookViewModel products = response.Content.ReadAsAsync<Models.BookViewModel>().Result;
            ViewBag.Title = "All Book";
            return View(products);
        }

        /// <summary>
        ///  Update information about the book.
        /// </summary>
        /// <param name="book">Book View Model </param>
        //[HttpPost]  
        public ActionResult Update(BookViewModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Book/UpdateBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }

        /// <summary>
        ///  Delete book from DB.
        /// </summary>
        /// <param name="id">Book ID</param>
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Book/DeleteBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }
    }
}