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
        private readonly LibraryContext _db;

        public UserRepository(LibraryContext context)
        {
            _db = context;
        }

        public IEnumerable<ClientProfile> GetAll()
        {
            return _db.ClientProfile.Include(o => o.Id);
        }

        public ClientProfile Get(int id)
        {
            return _db.ClientProfile.Find(id);
        }

        public void Create(ClientProfile clientProfile)
        {
            _db.ClientProfile.Add(clientProfile);
        }

        public void Update(ClientProfile clientProfile)
        {
            _db.Entry(clientProfile).State = EntityState.Modified;
        }

        public IEnumerable<ClientProfile> Find(Func<ClientProfile, bool> predicate)
        {
            return _db.ClientProfile.Include(o => o.Id).AsEnumerable().Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            var clientProfile = _db.ClientProfile.Find(id);
            if (clientProfile != null)
                _db.ClientProfile.Remove(clientProfile);
        }
    }
}
