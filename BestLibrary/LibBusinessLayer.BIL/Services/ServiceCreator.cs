using LibBusinessLayer.BIL.Interfaces;
using LibDataLayer.DAL.Repositories;

namespace LibBusinessLayer.BIL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
