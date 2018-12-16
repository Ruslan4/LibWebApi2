using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    public class CatalogBooksDto
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public bool HaveABook { get; set; }
    }
}
