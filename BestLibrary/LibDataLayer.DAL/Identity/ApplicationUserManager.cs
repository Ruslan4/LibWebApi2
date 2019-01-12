using LibDataLayer.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace LibDataLayer.DAL.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
    }
}
