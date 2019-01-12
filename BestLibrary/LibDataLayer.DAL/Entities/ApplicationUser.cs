using LibDataLayer.DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibDataLayer.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
