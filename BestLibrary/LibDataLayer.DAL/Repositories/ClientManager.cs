using LibDataLayer.DAL.EF_Context;
using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Models;

namespace LibDataLayer.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public LibraryContext Database { get; set; }
        public ClientManager(LibraryContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfile.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
