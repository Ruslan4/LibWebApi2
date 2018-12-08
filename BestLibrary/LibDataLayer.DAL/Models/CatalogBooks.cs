using System.Collections.Generic;

namespace LibDataLayer.DAL.Models
{
    public class CatalogBooks
    {
        public int CatalogBooksID { get; set; }
        public int BookID { get; set; }
        public bool HaveABook { get; set; }

        public virtual Book Books { get; set; }
        public virtual ICollection<IssuanceOfBooks> IssuanceOfBooks { get; set; }
    }
}
