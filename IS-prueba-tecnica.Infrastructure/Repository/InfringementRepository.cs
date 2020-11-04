using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using IS_prueba_tecnica.Domain.Entities;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public class InfringementRepository : GenericRepository<Infringement>, IInfringementRepository
    {
        public InfringementRepository(IPruebaTecnicaDbContext context) : base(context)
        {
        }
    }
}
