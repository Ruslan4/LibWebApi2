using LibDataLayer.DAL.Interfaces;
using LibDataLayer.DAL.Repositories;
using Ninject.Modules;

namespace LibBusinessLayer.BIL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
