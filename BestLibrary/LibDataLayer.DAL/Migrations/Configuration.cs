namespace LibDataLayer.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_Context.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EF_Context.LibraryContext context)
        {
            //var books = new List<Book> {
            //    new Book { BookÑipher = 5532532, Name = "Alexander", Author = "Alexander", Pages = 500, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 5 },
            //    new Book { BookÑipher = 7536364, Name = "Best book", Author = "Bob", Pages = 600, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 10 },
            //    new Book { BookÑipher = 7867457, Name = "Best book2", Author = "Another Bob", Pages = 700, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 50 },
            //    new Book { BookÑipher = 2457745, Name = "Best book3", Author = "Another Elis", Pages = 900, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 3 }
            //};

            //books.ForEach(s => context.Books.Add(s));
            //context.SaveChanges();

            //var catalog = new List<CatalogBooks>
            //{
            //    new CatalogBooks {Id = 4022, BookId = 1, HaveABook = true },
            //    new CatalogBooks {Id = 4041, BookId = 2, HaveABook = true },
            //    new CatalogBooks {Id = 3141, BookId = 3, HaveABook = true },
            //    new CatalogBooks {Id = 2021, BookId = 1, HaveABook = true },
            //    new CatalogBooks {Id = 2042, BookId = 2, HaveABook = true },
            //    new CatalogBooks {Id = 1050, BookId = 3, HaveABook = true },
            //    new CatalogBooks {Id = 1045, BookId = 1, HaveABook = true }
            //};
            //catalog.ForEach(s => context.CatalogBooks.Add(s));
            //context.SaveChanges();

            //var issuanceOfBooks = new List<IssuanceOfBooks>
            //{
            //    new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01"), },
            //    new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
            //    new IssuanceOfBooks{CatalogBooksId=1, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
            //    new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
            //    new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
            //    new IssuanceOfBooks{CatalogBooksId=2, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") },
            //    new IssuanceOfBooks{CatalogBooksId=3, DateIssue = DateTime.Parse("2005-09-01"), ReturnDate = DateTime.Parse("2005-09-01") }
            //};
            //issuanceOfBooks.ForEach(s => context.IssuanceOfBooks.Add(s));
            //context.SaveChanges();
        }
    }
}
