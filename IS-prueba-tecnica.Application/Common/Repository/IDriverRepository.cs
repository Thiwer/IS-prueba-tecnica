using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using IS_prueba_tecnica.Domain.Entities;

namespace IS_prueba_tecnica.Application.Common.Repository
{
    public interface IDriverRepository :
        ICreateRepository<Driver>,
        IPagedRepository<Driver>,
        IReadRepository<Driver>,
        IRemoveRepository<Driver>,
        IUpdateRepository<Driver>
    {
    }
}
