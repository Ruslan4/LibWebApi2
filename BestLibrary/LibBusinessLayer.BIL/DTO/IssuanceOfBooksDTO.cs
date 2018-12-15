using System;

namespace LibBusinessLayer.BIL.DTO
{
    public class IssuanceOfBooksDto
    {
        public string Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        public string ClientProfileId { get; set; }
    }
}
