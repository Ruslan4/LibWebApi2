using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    class CatalogBooksDTO
    {
        public int CatalogBooksId { get; set; }
        public int BookId { get; set; }
        public bool HaveABook { get; set; }
    }
}
