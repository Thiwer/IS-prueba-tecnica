using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using IS_prueba_tecnica.Domain.Entities;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(IPruebaTecnicaDbContext context) : base(context)
        {
        }
    }
}
