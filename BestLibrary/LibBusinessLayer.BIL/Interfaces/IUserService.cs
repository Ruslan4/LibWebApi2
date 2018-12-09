using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;

namespace LibBusinessLayer.BIL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(ClientProfileDto clientProfileDto);
        Task<ClaimsIdentity> Authenticate(ClientProfileDto clientProfileDto);
        Task SetInitialData(ClientProfileDto adminDto, List<string> roles);
    }
}
