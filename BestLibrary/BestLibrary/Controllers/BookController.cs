using AutoMapper;
using BestLibrary.Models;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace BestLibrary.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller for CRUD book operations in the library.
    /// </summary>
    public class BookController : ApiController
    {
        private readonly ILibraryService _libraryService;

        public BookController(ILibraryService serv)
        {
            _libraryService = serv;
        }
        /// <summary>
        /// Get all book from database.
        /// </summary>
        // GET: api/Book
        [HttpGet]
        public JsonResult<List<BookViewModel>> GetAllBooks()
        {
            var bookDtos = _libraryService.GetBooks();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, BookViewModel>()).CreateMapper();
            var books = mapper.Map<IEnumerable<BookDto>, List<BookViewModel>>(bookDtos);
            return Json(books);
        }
        /// <summary>
        /// Get book from database.
        /// </summary>
        /// <param name="id">Book ID </param>
        // GET: api/Book/id
        [HttpGet]
        public JsonResult<BookViewModel> GetBook(int id)
        {
            var bookDtos = _libraryService.GetBook(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookDto, BookViewModel>()).CreateMapper();
            var books = mapper.Map<BookDto, BookViewModel>(bookDtos);
            return Json<BookViewModel>(books);
        }
        /// <summary>
        /// Add new book in database.
        /// </summary>
        /// <param name="book">Book View Model </param>
        [HttpPost]
        public bool AddBook(BookViewModel book)
        {
            var status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var bookDto = new BookDto()
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

        /// <summary>
        /// Update book data in database.
        /// </summary>
        /// <param name="book">Book View Model </param>
        [HttpPut]
        public bool UpdateBook(BookViewModel book)
        {
            var status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var bookDto = new BookDto()
                    {
                        Id = book.Id,
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
        /// <summary>
        /// Delete book from database.
        /// </summary>
        /// <param name="id">Book ID</param>
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
