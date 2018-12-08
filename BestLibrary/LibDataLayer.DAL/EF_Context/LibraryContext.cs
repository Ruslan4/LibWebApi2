using LibDataLayer.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using LibDataLayer.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibDataLayer.DAL.EF_Context
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; } 
        public DbSet<IssuanceOfBooks> IssuanceOfBooks { get; set; }
        public DbSet<CatalogBooks> CatalogBooks { get; set; }

        static LibraryContext()
        {
            Database.SetInitializer(new LibInitializer());
        }
        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
