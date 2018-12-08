using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibDataLayer.DAL.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }


        public virtual ICollection<IssuanceOfBooks> IssuanceOfBooks { get; set; }
    }
}
