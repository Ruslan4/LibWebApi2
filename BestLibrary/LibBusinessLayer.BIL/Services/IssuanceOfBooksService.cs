using AutoMapper;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;


namespace LibBusinessLayer.BIL.Services
{
    public class IssuanceOfBooksService : IIssuanceOfBooksService
    {
        public IUnitOfWork Database { get; set; }
        //IssuanceOfBooksService в конструкторе принимает объект IUnitOfWork, через который идет взаимодействие с уровнем DAL.
        public IssuanceOfBooksService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public bool CreateIssuance(IssuanceOfBooksDto issuanceOfBooksDto)
        {
            bool status;
            try
            {             
                IssuanceOfBooks issuance = new IssuanceOfBooks
                {
                    CatalogBooksId = issuanceOfBooksDto.CatalogBooksId,
                    DateIssue = issuanceOfBooksDto.DateIssue,
                    ReturnDate = issuanceOfBooksDto.ReturnDate,
                    Id = issuanceOfBooksDto.Id
                    //ClientProfileId = issuanceOfBooksDto.ClientProfileId
                };
                Database.IssuanceOfBooks.Create(issuance);
                Database.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public IEnumerable<IssuanceOfBooksDto> GetIssuances()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooks, IssuanceOfBooksDto>()).CreateMapper();
            return mapper.Map<IEnumerable<IssuanceOfBooks>, List<IssuanceOfBooksDto>>(Database.IssuanceOfBooks.GetAll());
        }

        public bool ReturnIssuance(int id)
        {
            bool status;
            try
            {
                Database.IssuanceOfBooks.Delete(id);
                Database.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public IssuanceOfBooksDto GetIssuance(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var issuanceOfBooks = Database.IssuanceOfBooks.Get(id.Value);
            if (issuanceOfBooks == null)
                throw new ValidationException("Книга не найдена", "");

            return new IssuanceOfBooksDto
            {
                Id = issuanceOfBooks.Id,
                ReturnDate = issuanceOfBooks.ReturnDate,
                CatalogBooksId = issuanceOfBooks.CatalogBooksId
                //ClientProfileId = issuanceOfBooks.ClientProfileId
            };
        }

        public IssuanceOfBooksDto GetUserIssuance(int id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var issuanceOfBooks = Database.IssuanceOfBooks.Get(id);
            if (issuanceOfBooks == null)
                throw new ValidationException("Книга не найдена", "");

            return new IssuanceOfBooksDto
            {
                Id = issuanceOfBooks.Id,
                ReturnDate = issuanceOfBooks.ReturnDate,
                CatalogBooksId = issuanceOfBooks.CatalogBooksId
                //ClientProfileId = issuanceOfBooks.ClientProfileId
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
