using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;

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

        public bool AddIssuance(IssuanceOfBooksDTO issuanceOfBooksDto)
        {
            bool status;
            try
            {
                
                IssuanceOfBooks issuance = new IssuanceOfBooks
                {
                    CatalogBooksId = issuanceOfBooksDto.CatalogBooksId,
                    DateIssue = issuanceOfBooksDto.DateIssue,
                    ReturnDate = issuanceOfBooksDto.ReturnDate,
                    IssuanceOfBooksId = issuanceOfBooksDto.IssuanceOfBooksId
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

        public IEnumerable<IssuanceOfBooksDTO> GetIssuances()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IssuanceOfBooks, IssuanceOfBooksDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<IssuanceOfBooks>, List<IssuanceOfBooksDTO>>(Database.IssuanceOfBooks.GetAll());
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

        public IssuanceOfBooksDTO GetIssuance(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var issuanceOfBooks = Database.IssuanceOfBooks.Get(id.Value);
            if (issuanceOfBooks == null)
                throw new ValidationException("Книга не найдена", "");

            return new IssuanceOfBooksDTO
            {
                IssuanceOfBooksId = issuanceOfBooks.IssuanceOfBooksId,
                ReturnDate = issuanceOfBooks.ReturnDate,
                CatalogBooksId = issuanceOfBooks.CatalogBooksId
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
