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

        //The EFUnitOfWork class in the constructor takes a string - the name of the connection, which will then be passed to the constructor 
        //data context. Actually through EFUnitOfWork we will interact with the database.
        public EFUnitOfWork(string connectionString)
        {
            _db = new LibraryContext(connectionString);
        }
        public IRepository<Book> Books
        {
            get { return _bookRepository ?? (_bookRepository = new BookRepository(_db)); }
        }

        public IRepository<ClientProfile> ClientProfiles
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_db)); }
        }

        public IRepository<CatalogBooks> CatalogBooks
        {
            get { return _catalogBooksRepository ?? (_catalogBooksRepository = new CatalogBooksRepository(_db)); }
        }

        public IRepository<IssuanceOfBooks> IssuanceOfBooks
        {
            get
            { return _issuanceOfBooksRepository ?? (_issuanceOfBooksRepository = new IssuanceOfBooksRepository(_db)); }
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
