﻿using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPruebaTecnicaDbContext Context { get; }

        IVehicleRepository VehicleRepository { get; }

        void DetectChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
