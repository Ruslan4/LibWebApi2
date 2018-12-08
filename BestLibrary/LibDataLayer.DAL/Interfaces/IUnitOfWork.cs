﻿using LibDataLayer.DAL.Models;
using System;

namespace LibDataLayer.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ClientProfile> Users { get; }
        IRepository<Book> Books { get; }
        IRepository<IssuanceOfBooks> IssuanceOfBooks { get; }
        IRepository<CatalogBooks> CatalogBooks { get; }
        void Save();
    }
}