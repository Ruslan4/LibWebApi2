using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestLibrary.Models
{
    public class IssuanceOfBooksViewModel
    {
        public int IssuanceOfBooksId { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        //public IssuanceOfBooks() => DateIssue = DateTime.Now;
    }
}