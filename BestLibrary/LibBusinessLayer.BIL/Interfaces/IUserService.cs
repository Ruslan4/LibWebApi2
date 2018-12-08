using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibBusinessLayer.BIL.DTO;

namespace LibBusinessLayer.BIL.Interfaces
{
    public interface IUserService
    {
        void MakeUser(UserDTO userDto);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
