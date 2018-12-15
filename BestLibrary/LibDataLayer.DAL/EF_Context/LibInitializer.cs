using System;
using System.Collections.Generic;
using LibDataLayer.DAL.Models;

namespace LibDataLayer.DAL.EF_Context
{
    public class LibInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            var books = new List<Book> {
                new Book { BookСipher = 5532532, Name = " C# 5.0 и платформа .NET 4.5", Author = "Эндрю Троелсен ", Pages = 500, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 5 },
                new Book { BookСipher = 7536364, Name = "CLR-via-C.-Программирование-на-платформе-Microsoft-.NET-Framework-4.5", Author = "Рихтер-Дж.", Pages = 1200, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 10 },
                new Book { BookСipher = 7867457, Name = "Design Patterns", Author = "Andriy Buday", Pages = 700, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 50 },
                new Book { BookСipher = 2457745, Name = "oop composition", Author = "Elis", Pages = 900, PrintDate = DateTime.Parse("2005-09-01"), CountBook = 3 }
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

            var catalog = new List<CatalogBooks>
            {
                new CatalogBooks { BookId = 1, HaveABook = true },
                new CatalogBooks { BookId = 2, HaveABook = true },
                new CatalogBooks { BookId = 3, HaveABook = true },
                new CatalogBooks { BookId = 1, HaveABook = true },
                new CatalogBooks { BookId = 2, HaveABook = true },
                new CatalogBooks { BookId = 3, HaveABook = true },
                new CatalogBooks { BookId = 1, HaveABook = true }
            };
            catalog.ForEach(s => context.CatalogBooks.Add(s));
            context.SaveChanges();

            var issuanceOfBooks = new List<IssuanceOfBooks>
            {
                new IssuanceOfBooks{CatalogBooksId=2, ReturnDate = DateTime.Parse("2005-09-01"),ClientProfileId = "0", DateIssue = DateTime.Parse("2005-09-01") },
                new IssuanceOfBooks{CatalogBooksId=1, ReturnDate = DateTime.Parse("2005-09-01"),ClientProfileId = "0", DateIssue = DateTime.Parse("2005-09-01") }
            };
            issuanceOfBooks.ForEach(s => context.IssuanceOfBooks.Add(s));
            context.SaveChanges();
        }
    }
}
