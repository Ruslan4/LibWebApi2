using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.DTO
{
    /// <summary>
    /// Data Transfer Object (DTO) - special model for data transfer (CatalogBooks).
    /// </summary>
    public class CatalogBooksDto
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public bool HaveABook { get; set; }
    }
}
