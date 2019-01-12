using LibBusinessLayer.BIL.DTO;
using LibBusinessLayer.BIL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibBusinessLayer.BIL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(ClientProfileDto clientProfileDto);
        Task<ClaimsIdentity> Authenticate(ClientProfileDto clientProfileDto);
        Task SetInitialData(ClientProfileDto adminDto, List<string> roles);
        ClientProfileDto GetCurrentUser();
    }
}
