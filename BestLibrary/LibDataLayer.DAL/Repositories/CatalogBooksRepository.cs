using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibDataLayer.DAL.Repositories
{
    public class CatalogBooksRepository : IRepository<CatalogBooks>
    {
        private readonly LibraryContext _db;

        public CatalogBooksRepository(LibraryContext context)
        {
            this._db = context;
        }

        public IEnumerable<CatalogBooks> GetAll()
        {
            return _db.CatalogBooks;
        }

        public CatalogBooks Get(int id)
        {
            return _db.CatalogBooks.Find(id);
        }

        public void Create(CatalogBooks catalogBooks)
        {
            _db.CatalogBooks.Add(catalogBooks);
        }

        public void Update(CatalogBooks catalogBooks)
        {
            _db.Entry(catalogBooks).State = EntityState.Modified;
        }

        public IEnumerable<CatalogBooks> Find(Func<CatalogBooks, Boolean> predicate)
        {
            return _db.CatalogBooks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CatalogBooks catalogBooks = _db.CatalogBooks.Find(id);
            if (catalogBooks != null)
                _db.CatalogBooks.Remove(catalogBooks);
        }
    }
}
