﻿using System;
using AutoMapper;
using BestLibrary.Models;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace BestLibrary.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Issuance of Books Controller.
    /// </summary>
    public class IssuanceOfBooksController : ApiController
    {
        private readonly IIssuanceOfBooksService _libraryService;

        public IssuanceOfBooksController(IIssuanceOfBooksService serv)
        {
            _libraryService = serv;
        }

        /// <summary>
        /// Get all Issuance Of Books the current reader from the database.
        /// </summary>
        /// <param name="id">Current User ID.</param>
        // GET: api/IssuanceOfBooks
        [HttpGet]
        public JsonResult<List<IssuanceOfBooksViewModel>> GetAllIssuances(string id)
        {
            IEnumerable<IssuanceOfBooksDto> issuanceOfBooksDtos = _libraryService.GetIssuances();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooksDto, IssuanceOfBooksViewModel>()).CreateMapper();
            List<IssuanceOfBooksViewModel> issuance = mapper.Map<IEnumerable<IssuanceOfBooksDto>, List<IssuanceOfBooksViewModel>>(issuanceOfBooksDtos);
            var issuanceCurrentUser =
                from item in issuance
                where item.ClientProfileId == id
                select new IssuanceOfBooksViewModel
                {
                    Id = item.Id,
                    ClientProfileId = item.ClientProfileId,
                    ReturnDate = item.ReturnDate,
                    CatalogBooksId = item.CatalogBooksId,
                    DateIssue = item.DateIssue
                };
            return Json(issuanceCurrentUser.ToList());
        }

        /// <summary>
        /// Add new Issuance in database.
        /// </summary>
        /// <param name="book">Issuance Of Books ViewModel </param>
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

        /// <summary>
        /// Return Issuance in  lib (delete Issuance).
        /// </summary>
        /// <param name="id">Issuance ID </param>
        [HttpDelete]
        public bool ReturnIssuance(int id)
        {
            return _libraryService.ReturnIssuance(id);
        }

        /// <inheritdoc />
        /// <summary>
        /// Dispose of resources.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            _libraryService.Dispose();
            base.Dispose(disposing);
        }
    }
}
