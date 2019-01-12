using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibDataLayer.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _db;

        public BookRepository(LibraryContext context)
        {
            this._db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public void Create(Book book)
        {
            _db.Books.Add(book);
        }

        public void Update(Book book)
        {
            _db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Book> Find(Func<Book, Boolean> predicate)
        {
            return _db.Books.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Book book = _db.Books.Find(id);
            if (book != null)
                _db.Books.Remove(book);
        }
    }
}
