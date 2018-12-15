using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LibDataLayer.DAL.Entities;

namespace LibDataLayer.DAL.Models
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public string IssuanceOfBooksId { get; set; }
        public virtual ICollection<IssuanceOfBooks> IssuanceOfBooks { get; set; }
    }
}
