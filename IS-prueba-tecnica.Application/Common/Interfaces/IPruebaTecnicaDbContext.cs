using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.Interfaces
{
    public interface IPruebaTecnicaDbContext
    {

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbConnection GetDbConnection();
    }
}
