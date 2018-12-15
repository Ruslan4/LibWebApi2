using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibDataLayer.DAL.Repositories
{
    public class IssuanceOfBooksRepository : IRepository<IssuanceOfBooks>
    {
        private readonly LibraryContext _db;

        public IssuanceOfBooksRepository(LibraryContext context)
        {
            this._db = context;
        }

        public IEnumerable<IssuanceOfBooks> GetAll()
        {
            return _db.IssuanceOfBooks;
        }

        public IssuanceOfBooks Get(int id)
        {
            return _db.IssuanceOfBooks.Find(id);
        }

        public void Create(IssuanceOfBooks issuanceOfBooks)
        {
            _db.IssuanceOfBooks.Add(issuanceOfBooks);
        }

        public void Update(IssuanceOfBooks issuanceOfBooks)
        {
            _db.Entry(issuanceOfBooks).State = EntityState.Modified;
        }

        public IEnumerable<IssuanceOfBooks> Find(Func<IssuanceOfBooks, bool> predicate)
        {
            return _db.IssuanceOfBooks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var issuanceOfBooks = _db.IssuanceOfBooks.Find(id);
            if (issuanceOfBooks != null)
                _db.IssuanceOfBooks.Remove(issuanceOfBooks);
        }
    }
}
