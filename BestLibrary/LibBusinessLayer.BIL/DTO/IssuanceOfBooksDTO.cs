using System;

namespace LibBusinessLayer.BIL.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) - special model for data transfer (IssuanceOfBooksDto).
    /// </summary>
    public class IssuanceOfBooksDto
    {
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        public string ClientProfileId { get; set; }
    }
}
