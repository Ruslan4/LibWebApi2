using AutoMapper;
using BestLibrary.Models;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace BestLibrary.Controllers
{
    public class BookController : ApiController
    {
        readonly ILibraryService _libraryService;

        public BookController(ILibraryService serv)
        {
            _libraryService = serv;
        }

        // GET: api/Book
        [HttpGet]
        public JsonResult<List<BookViewModel>> GetAllBooks()
        {
            IEnumerable<BookDTO> bookDtos = _libraryService.GetBooks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDTO>, List<BookViewModel>>(bookDtos);
            return Json(books);
        }

        // GET: api/Book/id
        [HttpGet]
        public JsonResult<BookViewModel> GetBook(int id)
        {
            BookDTO bookDtos = _libraryService.GetBook(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDTO, BookViewModel>()).CreateMapper();
            var books = mapper.Map<BookDTO, BookViewModel>(bookDtos);
            return Json<BookViewModel>(books);
        }

        [HttpPost]
        public bool AddBook(BookViewModel book)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var bookDto = new BookDTO()
                    {
                        Author = book.Author,
                        Name = book.Name,
                        BookСipher = book.BookСipher,
                        CountBook = book.CountBook,
                        Pages = book.Pages,
                        PrintDate = book.PrintDate
                    };

                    status = _libraryService.AddBook(bookDto);
                }
                catch (System.Exception)
                {
                    status = false;
                }
            }
            return status;
        }

        [HttpPut]
        public bool UpdateBook(BookViewModel book)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var bookDto = new BookDTO()
                    {
                        BookID = book.BookID,
                        Author = book.Author,
                        Name = book.Name,
                        BookСipher = book.BookСipher,
                        CountBook = book.CountBook,
                        Pages = book.Pages,
                        PrintDate = book.PrintDate
                    };

                    status = _libraryService.UpdateBook(bookDto);
                }
                catch (System.Exception)
                {
                    status = false;
                }
            }
            return status;

        }


        [HttpDelete]
        public bool DeleteBook(int id)
        {
            return _libraryService.DeleteBook(id);
        }

        protected override void Dispose(bool disposing)
        {
            _libraryService.Dispose();
            base.Dispose(disposing);
        }
    }
}
