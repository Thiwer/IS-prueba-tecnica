using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Infrastructure.Persistence;

namespace IS_prueba_tecnica.Infrastructure.UnitOfWork
{
    public class UnitOfWorkContainer : IUnitOfWork
    {
        private readonly PruebaTecnicaDbContext _context;

        public IPruebaTecnicaDbContext Context => _context;


        public IVehicleRepository VehicleRepository { get; }


        public UnitOfWorkContainer(PruebaTecnicaDbContext context)
        {
            _context = context;

            VehicleRepository = new VehicleRepository(context);
        }

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}
