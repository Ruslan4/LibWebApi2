using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LibDataLayer.DAL.Repositories
{
    public class UserRepository : IRepository<ClientProfile>
    {
        private LibraryContext db;

        public UserRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return db.ClientProfiles.Include(o => o.Id);
        }

        public ClientProfile Get(int id)
        {
            return db.ClientProfiles.Find(id);
        }

        public void Create(ClientProfile clientProfile)
        {
            db.ClientProfiles.Add(clientProfile);
        }

        public void Update(ClientProfile clientProfile)
        {
            db.Entry(clientProfile).State = EntityState.Modified;
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, Boolean> predicate)
        {
            return db.ClientProfiles.Include(o => o.Id).AsEnumerable().Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ClientProfile clientProfile = db.ClientProfiles.Find(id);
            if (clientProfile != null)
                db.ClientProfiles.Remove(clientProfile);
        }
    }
}
