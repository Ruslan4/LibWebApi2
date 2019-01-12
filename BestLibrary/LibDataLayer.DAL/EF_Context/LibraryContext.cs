using LibDataLayer.DAL.Entities;
using LibDataLayer.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LibDataLayer.DAL.EF_Context
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {
        static LibraryContext()
        {
            Database.SetInitializer(new LibInitializer());
        }

        public LibraryContext()
            : base("DefaultConnection")
        {
        }

        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<ClientProfile> ClientProfile { get; set; }
        public DbSet<IssuanceOfBooks> IssuanceOfBooks { get; set; }
        public DbSet<CatalogBooks> CatalogBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
