using System;

namespace BestLibrary.Models
{
    public class IssuanceOfBooksViewModel
    {
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }
        public int ClientProfileId { get; set; }

        //public IssuanceOfBooks() => DateIssue = DateTime.Now;
    }
}