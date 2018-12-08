using LibDataLayer.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace LibDataLayer.DAL.Interfaces
{
    public interface IUnitOfWorkUser : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
