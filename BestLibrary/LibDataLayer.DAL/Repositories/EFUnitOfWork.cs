using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;

namespace LibDataLayer.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private LibraryContext db;
        private BookRepository bookRepository;
        private UserRepository userRepository;
        private IssuanceOfBooksRepository IssuanceOfBooksRepository;
        private CatalogBooksRepository CatalogBooksRepository;

        //Класс EFUnitOfWork в конструкторе принимает строку - названия подключения, которая потом будет передаваться в конструктор 
        //контекста данных. Собственно через EFUnitOfWork мы и будем взаимодействовать с базой данных.

        public EFUnitOfWork(string connectionString)
        {
            db = new LibraryContext(connectionString);
        }
        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }

        public IRepository<ClientProfile> ClientProfiles
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public IRepository<CatalogBooks> CatalogBooks
        {
            get
            {
                if (CatalogBooksRepository == null)
                    CatalogBooksRepository = new CatalogBooksRepository(db);
                return CatalogBooksRepository;
            }
        }

        public IRepository<IssuanceOfBooks> IssuanceOfBooks
        {
            get
            {
                if (IssuanceOfBooksRepository == null)
                    IssuanceOfBooksRepository = new IssuanceOfBooksRepository(db);
                return IssuanceOfBooksRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
