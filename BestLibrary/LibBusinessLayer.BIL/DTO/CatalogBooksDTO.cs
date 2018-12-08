using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    class CatalogBooksDTO
    {
        public int CatalogBooksID { get; set; }
        public int BookID { get; set; }
        public bool HaveABook { get; set; }
    }
}
