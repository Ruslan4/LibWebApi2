﻿using System;

namespace LibDataLayer.DAL.Models
{
    public class IssuanceOfBooks
    {
        public int IssuanceOfBooksId { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }
        public virtual CatalogBooks CatalogBooks { get; set; }

        public virtual ClientProfile ClientProfile { get; set; }

        //public IssuanceOfBooks() => DateIssue = DateTime.Now;
    }
}
