using AutoMapper;
using BestLibrary.Models;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace BestLibrary.Controllers
{
    public class IssuanceOfBooksController : ApiController
    {
        readonly IIssuanceOfBooksService _libraryService;

        public IssuanceOfBooksController(IIssuanceOfBooksService serv)
        {
            _libraryService = serv;
        }

        // GET: api/Book
        [HttpGet]
        public JsonResult<List<IssuanceOfBooksViewModel>> GetAllIssuances()
        {
            IEnumerable<IssuanceOfBooksDTO> issuanceOfBooksDtos = _libraryService.GetIssuances();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooksDTO, IssuanceOfBooksViewModel>()).CreateMapper();
            var issuance = mapper.Map<IEnumerable<IssuanceOfBooksDTO>, List<IssuanceOfBooksViewModel>>(issuanceOfBooksDtos);
            return Json(issuance);
        }

        // GET: api/Book/id
        [HttpGet]
        public JsonResult<IssuanceOfBooksViewModel> GetIssuance(int id)
        {
            IssuanceOfBooksDTO issuanceOfBooksDto = _libraryService.GetIssuance(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooksDTO, IssuanceOfBooksViewModel>()).CreateMapper();
            var books = mapper.Map<IssuanceOfBooksDTO, IssuanceOfBooksViewModel>(issuanceOfBooksDto);
            return Json<IssuanceOfBooksViewModel>(books);
        }

        [HttpPost]
        public bool AddIssuance(IssuanceOfBooksViewModel book)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    var issuanceOfBooksDto = new IssuanceOfBooksDTO()
                    {
                        
                        ReturnDate = book.ReturnDate,
                        DateIssue = book.DateIssue,
                        CatalogBooksId = book.CatalogBooksId,
                        IssuanceOfBooksId = book.IssuanceOfBooksId
                    };

                    status = _libraryService.AddIssuance(issuanceOfBooksDto);
                }
                catch (System.Exception)
                {
                    status = false;
                }
            }
            return status;
        }

        [HttpDelete]
        public bool ReturnIssuance(int id)
        {
            return _libraryService.ReturnIssuance(id);
        }

        protected override void Dispose(bool disposing)
        {
            _libraryService.Dispose();
            base.Dispose(disposing);
        }
    }

}
