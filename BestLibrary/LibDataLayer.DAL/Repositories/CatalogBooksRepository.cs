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
        private LibraryContext db;

        public CatalogBooksRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<CatalogBooks> GetAll()
        {
            return db.CatalogBooks;
        }

        public CatalogBooks Get(int id)
        {
            return db.CatalogBooks.Find(id);
        }

        public void Create(CatalogBooks catalogBooks)
        {
            db.CatalogBooks.Add(catalogBooks);
        }

        public void Update(CatalogBooks catalogBooks)
        {
            db.Entry(catalogBooks).State = EntityState.Modified;
        }

        public IEnumerable<CatalogBooks> Find(Func<CatalogBooks, Boolean> predicate)
        {
            return db.CatalogBooks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            CatalogBooks catalogBooks = db.CatalogBooks.Find(id);
            if (catalogBooks != null)
                db.CatalogBooks.Remove(catalogBooks);
        }
    }
}
