using System.Collections.Generic;

namespace LibDataLayer.DAL.Models
{
    public class CatalogBooks
    {
        public int CatalogBooksId { get; set; }
        public int BookId { get; set; }
        public bool HaveABook { get; set; }

        public virtual Book Book { get; set; }
        public virtual ICollection<IssuanceOfBooks> IssuanceOfBooks { get; set; }
    }
}
