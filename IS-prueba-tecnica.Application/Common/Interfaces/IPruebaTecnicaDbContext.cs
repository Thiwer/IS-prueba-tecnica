using IS_prueba_tecnica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.Interfaces
{
    public interface IPruebaTecnicaDbContext
    {

        DbSet<Vehicle> Vehicles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbConnection GetDbConnection();
    }
}
