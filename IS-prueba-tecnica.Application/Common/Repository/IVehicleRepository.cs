using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using IS_prueba_tecnica.Domain.Entities;

namespace IS_prueba_tecnica.Application.Common.Repository
{
    public interface IVehicleRepository :
        ICreateRepository<Vehicle>,
        IPagedRepository<Vehicle>,
        IReadRepository<Vehicle>,
        IRemoveRepository<Vehicle>,
        IUpdateRepository<Vehicle>
    {
    }
}
