using System;
using System.Collections.Generic;

namespace LibDataLayer.DAL.Models
{
    public class IssuanceOfBooks
    {

        public int IssuanceOfBooksId { get; set; }
        public int UserID { get; set; }
        public int CatalogBooksID { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual CatalogBooks CatalogBooks { get; set; }

        public virtual ICollection<ClientProfile> ClientProfile { get; set; }

        //public IssuanceOfBooks() => DateIssue = DateTime.Now;
    }
}
