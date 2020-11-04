using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPruebaTecnicaDbContext Context { get; }

        IVehicleRepository VehicleRepository { get; }
        IDriverRepository DriverRepository { get; }
        IInfringementRepository InfringementRepository { get; }
        IVehicleDriverRepository VehicleDriverRepository { get; }
        IInfringementVehicleDriverRepository InfringementVehicleDriverRepository { get; }

        void DetectChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
