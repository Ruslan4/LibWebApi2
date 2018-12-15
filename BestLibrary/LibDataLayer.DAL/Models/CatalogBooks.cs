using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibDataLayer.DAL.Models
{
    public class CatalogBooks
    {
        [Key]
        public int Id { get; set; }
        public bool HaveABook { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public virtual ICollection<IssuanceOfBooks> IssuanceOfBooks { get; set; }
    }
}
