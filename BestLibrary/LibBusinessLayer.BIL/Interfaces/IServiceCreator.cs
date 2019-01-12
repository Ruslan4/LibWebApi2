using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.Interfaces
{
    //I will use the abstract factory that the interface will represent IServiceCreator.
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
