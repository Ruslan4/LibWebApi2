using LibBusinessLayer.BIL.Interfaces;
using LibBusinessLayer.BIL.Services;
using Ninject.Modules;

namespace BestLibrary.Util
{
    /// <inheritdoc />
    /// <summary>
    /// We register dependencies globally for all controllers and for this we will create a new Util folder
    /// in the project and place the new NinjectRegistrations class.
    /// </summary>
    public class LibraryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILibraryService>().To<LibraryService>();
            Bind<IUserService>().To<UserService>();
            Bind<IIssuanceOfBooksService>().To<IssuanceOfBooksService>();
        }
    }
}