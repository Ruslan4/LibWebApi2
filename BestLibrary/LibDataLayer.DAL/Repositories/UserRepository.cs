using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibDataLayer.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private LibraryContext db;

        public UserRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.Include(o => o.UserId);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Include(o => o.UserId).AsEnumerable().Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
