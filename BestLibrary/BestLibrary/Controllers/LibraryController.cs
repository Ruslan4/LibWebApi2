﻿using BestLibrary.Models;
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

        [HttpPost]
        public ActionResult CreateBook(Models.BookViewModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Book/AddBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }

        public ActionResult Details(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Book/GetBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            Models.BookViewModel products = response.Content.ReadAsAsync<Models.BookViewModel>().Result;
            ViewBag.Title = "All Book";
            return View(products);
        }

        //[HttpPost]  
        public ActionResult Update(BookViewModel book)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Book/UpdateBook", book);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }

        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/Book/DeleteBook?id=" + id.ToString());
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllBooks");
        }
    }
}