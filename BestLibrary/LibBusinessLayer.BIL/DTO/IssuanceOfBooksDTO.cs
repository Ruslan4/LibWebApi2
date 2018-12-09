using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    public class IssuanceOfBooksDTO
    {
        public int IssuanceOfBooksId { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }

        public int CatalogBooksId { get; set; }

        public string ClientProfileId { get; set; }
        public IssuanceOfBooksDTO() => DateIssue = DateTime.Now;
    }
}
