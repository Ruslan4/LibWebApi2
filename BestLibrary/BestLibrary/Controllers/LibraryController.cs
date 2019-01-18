using BestLibrary.Models;
using BestLibrary.Services;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace BestLibrary.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller of work with library information system.
    /// </summary>
    [Authorize]
    public class LibraryController : Controller
    {
        /// <summary>
        /// Return  Electronic Subscriptions  lib.
        /// </summary>
        [HttpGet]
        public ActionResult ElectronicSubscriptions()
        {
            string id = User.Identity.GetUserId();

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/IssuanceOfBooks/GetAllIssuances?id=" + id);
            response.EnsureSuccessStatusCode();
            List<IssuanceOfBooksViewModel> subscriptions = response.Content.ReadAsAsync<List<IssuanceOfBooksViewModel>>().Result;

            return View(subscriptions);
        }

        /// <summary>
        /// Get All Books from lib.
        /// </summary>
        // GET: Library
        [Authorize]
        public ActionResult GetAllBooks()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Book/");
            response.EnsureSuccessStatusCode();
            List<BookViewModel> books = response.Content.ReadAsAsync<List<BookViewModel>>().Result;
            ViewBag.Title = "All books";
            return View(books);
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

        /// <summary>
        ///  HttpGet - Create new Book in lib.
        /// </summary>
        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        /// <summary>
        ///  HttpPost - Create new Book in lib.
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