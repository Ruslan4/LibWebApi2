using System.Collections.Generic;
using LibDataLayer.DAL.Models;

namespace LibDataLayer.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibDataLayer.DAL.EF_Context.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibDataLayer.DAL.EF_Context.LibraryContext context)
        {
            var books = new List<Book> {
                new Book {/*BookID = 11,*/ BookÑipher = 5532532, Name = "Alexander", Author = "Alexander", Pages = 500, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 5 },
                new Book {/*BookID = 22,*/ BookÑipher = 7536364, Name = "Best book", Author = "Bob", Pages = 600, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 10 },
                new Book {/*BookID = 33,*/ BookÑipher = 7867457, Name = "Best book2", Author = "Another Bob", Pages = 700, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 50 },
                new Book {/*BookID = 44,*/ BookÑipher = 2457745, Name = "Best book3", Author = "Another Elis", Pages = 900, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 3 }
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

            var catalog = new List<CatalogBooks>
            {
                new CatalogBooks {CatalogBooksId = 4022, BookId = 1, HaveABook = true},
                new CatalogBooks {CatalogBooksId = 4041, BookId = 2, HaveABook = true },
                new CatalogBooks {CatalogBooksId = 3141, BookId = 3, HaveABook = true },
                new CatalogBooks {CatalogBooksId = 2021, BookId = 1, HaveABook = true },
                new CatalogBooks {CatalogBooksId = 2042, BookId = 2, HaveABook = true },
                new CatalogBooks {CatalogBooksId = 1050, BookId = 3, HaveABook = true },
                new CatalogBooks {CatalogBooksId = 1045, BookId = 1, HaveABook = true }
            };
            catalog.ForEach(s => context.CatalogBooks.Add(s));
            context.SaveChanges();

            //var users = new List<ClientProfiles>
            //{
            //    new ClientProfiles {UserId = 4022, FirstName = "Bob", LastName = "Boo boo" ,Age = 10,Email = "hrtabsr",PhoneNumber = "235324"},
            //    new ClientProfiles {UserId = 4041, FirstName = "Bob1", LastName = "Boo boo1",Age = 22,Email = "erger",PhoneNumber = "235324" },
            //    new ClientProfiles {UserId = 3141, FirstName = "Bob2", LastName = "Boo boo2",Age = 33,Email = "gerg",PhoneNumber = "235324" },
            //    new ClientProfiles {UserId = 2021, FirstName = "Bob3", LastName = "Boo boo3",Age = 44,Email = "hrtabsr",PhoneNumber = "235324" }
            //};
            //users.ForEach(s => context.ClientProfiles.Add(s));
            //context.SaveChanges();

            var issuanceOfBooks = new List<IssuanceOfBooks>
            {
                new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=3, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") }
            };
            issuanceOfBooks.ForEach(s => context.IssuanceOfBooks.Add(s));
            context.SaveChanges();
        }
    }
}
