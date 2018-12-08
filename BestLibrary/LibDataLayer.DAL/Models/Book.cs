using System;
using System.Collections.Generic;

namespace LibDataLayer.DAL.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int BookСipher { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public DateTime PrintDate { get; set; }
        public int CountBook { get; set; }

        public virtual ICollection<CatalogBooks> CatalogBooks { get; set; }
    }
}
