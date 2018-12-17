using System;

namespace BestLibrary.Models
{
    /// <summary>
    /// Models returned by actions IssuanceController.
    /// </summary>
    public class IssuanceOfBooksViewModel
    {
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        public string ClientProfileId { get; set; }
    }
}