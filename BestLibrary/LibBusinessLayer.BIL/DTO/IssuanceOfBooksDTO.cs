using System;

namespace LibBusinessLayer.BIL.DTO
{
    public class IssuanceOfBooksDto
    {
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }
        public int ClientProfileId { get; set; }

        //public IssuanceOfBooksDto() => DateIssue = DateTime.Now;
    }
}
