using LibDataLayer.DAL.Models;
using System;

namespace LibDataLayer.DAL.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
