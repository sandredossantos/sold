﻿using Sold.Services.Core.DomainObjects;
using System;

namespace Sold.Services.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}