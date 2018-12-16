using System;

namespace BestLibrary.Models
{
    public class IssuanceOfBooksViewModel
    {
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        public string ClientProfileId { get; set; }
    }
}