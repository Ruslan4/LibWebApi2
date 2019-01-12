using System;
using System.ComponentModel.DataAnnotations;

namespace LibDataLayer.DAL.Models
{
    public class IssuanceOfBooks
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }
        public virtual CatalogBooks CatalogBooks { get; set; }

        public string ClientProfileId { get; set; }
        public virtual ClientProfile ClientProfile { get; set; }

    }
}
