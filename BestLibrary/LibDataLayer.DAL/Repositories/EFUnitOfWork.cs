using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;

namespace LibDataLayer.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _db;
        private BookRepository _bookRepository;
        private UserRepository _userRepository;
        private IssuanceOfBooksRepository _issuanceOfBooksRepository;
        private CatalogBooksRepository _catalogBooksRepository;

        //Класс EFUnitOfWork в конструкторе принимает строку - названия подключения, которая потом будет передаваться в конструктор 
        //контекста данных. Собственно через EFUnitOfWork мы и будем взаимодействовать с базой данных.

        public EFUnitOfWork(string connectionString)
        {
            _db = new LibraryContext(connectionString);
        }
        public IRepository<Book> Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_db);
                return _bookRepository;
            }
        }

        public IRepository<ClientProfile> ClientProfiles
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_db);
                return _userRepository;
            }
        }

        public IRepository<CatalogBooks> CatalogBooks
        {
            get
            {
                if (_catalogBooksRepository == null)
                    _catalogBooksRepository = new CatalogBooksRepository(_db);
                return _catalogBooksRepository;
            }
        }

        public IRepository<IssuanceOfBooks> IssuanceOfBooks
        {
            get
            {
                if (_issuanceOfBooksRepository == null)
                    _issuanceOfBooksRepository = new IssuanceOfBooksRepository(_db);
                return _issuanceOfBooksRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
