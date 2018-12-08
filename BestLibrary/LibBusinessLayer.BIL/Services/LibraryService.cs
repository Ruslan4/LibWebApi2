using System;
using AutoMapper;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System.Collections.Generic;

namespace LibBusinessLayer.BIL.Services
{
    public class LibraryService : ILibraryService
    {
        public IUnitOfWork Database { get; set; }

        //LibraryService в конструкторе принимает объект IUnitOfWork, через который идет взаимодействие с уровнем DAL.
        public LibraryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        //Метод MakeUser() получает объект для сохранения с уровня представления и создает по нему объект ClientProfiles и сохраняет его в базу данных.
        public void MakeUser(UserDto userDto)
        {
            Book book = Database.Books.Get(5);

            // валидация
            if (book == null)
                throw new ValidationException("Книга не найдена", "");

            //TODO: Дополнительная логика

            ClientProfile clientProfile = new ClientProfile
            {
                //BookId = book.Id,
                Address = userDto.Address,
                Name = userDto.Name
            };
            Database.Users.Create(clientProfile);
            Database.Save();
        }

        public bool AddBook(BookDTO bookDto)
        {
            bool status;
            try
            {
                Book book = new Book
                {
                    Name = bookDto.Name,
                    Author = bookDto.Author,
                    PrintDate = bookDto.PrintDate,
                    BookСipher = bookDto.BookСipher,
                    CountBook = bookDto.CountBook,
                    Pages = bookDto.Pages
                };
                Database.Books.Create(book);
                Database.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public bool UpdateBook(BookDTO bookDto)
        {
            bool status = false;
            try
            {
                Book book = new Book
                {
                    BookId = bookDto.BookID,
                    Author = bookDto.Author,
                    Name = bookDto.Name,
                    BookСipher = bookDto.BookСipher,
                    CountBook = bookDto.CountBook,
                    Pages = bookDto.Pages,
                    PrintDate = bookDto.PrintDate
                };
                Database.Books.Update(book);
                Database.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Book>, List<BookDTO>>(Database.Books.GetAll());
        }

        public bool DeleteBook(int id)
        {
            bool status;
            try
            {
                Database.Books.Delete(id);
                Database.Save();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }

        public BookDTO GetBook(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id книги", "");
            var book = Database.Books.Get(id.Value);
            if (book == null)
                throw new ValidationException("Книга не найдена", "");

            return new BookDTO
            {
                BookID = book.BookId,
                Name = book.Name,
                Author = book.Author,
                Pages = book.Pages,
                PrintDate = book.PrintDate,
                BookСipher = book.BookСipher,
                CountBook = book.CountBook
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
