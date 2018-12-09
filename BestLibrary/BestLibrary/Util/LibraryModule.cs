using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibBusinessLayer.BIL.Interfaces;
using LibBusinessLayer.BIL.Services;
using Ninject.Modules;
using Ninject.Web.Common;

namespace BestLibrary.Util
{
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