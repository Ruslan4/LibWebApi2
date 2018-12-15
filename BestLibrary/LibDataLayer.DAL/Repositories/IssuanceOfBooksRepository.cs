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
        private readonly LibraryContext db;

        public IssuanceOfBooksRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<IssuanceOfBooks> GetAll()
        {
            return db.IssuanceOfBooks;
        }

        public IssuanceOfBooks Get(int id)
        {
            return db.IssuanceOfBooks.Find(id);
        }

        public void Create(IssuanceOfBooks issuanceOfBooks)
        {
            db.IssuanceOfBooks.Add(issuanceOfBooks);
        }

        public void Update(IssuanceOfBooks issuanceOfBooks)
        {
            db.Entry(issuanceOfBooks).State = EntityState.Modified;
        }

        public IEnumerable<IssuanceOfBooks> Find(Func<IssuanceOfBooks, bool> predicate)
        {
            return db.IssuanceOfBooks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            IssuanceOfBooks issuanceOfBooks = db.IssuanceOfBooks.Find(id);
            if (issuanceOfBooks != null)
                db.IssuanceOfBooks.Remove(issuanceOfBooks);
        }
    }
}
