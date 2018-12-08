using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    public class IssuanceOfBooksDTO
    {
        public int IssuanceOfBooksID { get; set; }
        public int UserID { get; set; }
        public int CatalogBooksID { get; set; }

        public DateTime DateIssue { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
