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



        // GET: api/IssuanceOfBooks
        [HttpGet]
        public JsonResult<List<IssuanceOfBooksViewModel>> GetAllIssuances()
        {
            IEnumerable<IssuanceOfBooksDto> issuanceOfBooksDtos = _libraryService.GetIssuances();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooksDto, IssuanceOfBooksViewModel>()).CreateMapper();
            var issuance = mapper.Map<IEnumerable<IssuanceOfBooksDto>, List<IssuanceOfBooksViewModel>>(issuanceOfBooksDtos);
            return Json(issuance);
        }

        // GET: api/IssuanceOfBooks/id
        [HttpGet]
        public JsonResult<IssuanceOfBooksViewModel> GetIssuance(int id)
        {
            IssuanceOfBooksDto issuanceOfBooksDto = _libraryService.GetIssuance(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooksDto, IssuanceOfBooksViewModel>()).CreateMapper();
            var books = mapper.Map<IssuanceOfBooksDto, IssuanceOfBooksViewModel>(issuanceOfBooksDto);
            return Json<IssuanceOfBooksViewModel>(books);
        }

        [HttpPost]
        public bool CreateIssuance(IssuanceOfBooksViewModel book)
        {
            bool status;
            if (!ModelState.IsValid) return false;
            try
            {
                var issuanceOfBooksDto = new IssuanceOfBooksDto()
                { 
                    ReturnDate = book.ReturnDate,
                    DateIssue = book.DateIssue,
                    CatalogBooksId = book.CatalogBooksId,
                    Id = book.Id
                };

                status = _libraryService.CreateIssuance(issuanceOfBooksDto);
            }
            catch (System.Exception)
            {
                status = false;
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
