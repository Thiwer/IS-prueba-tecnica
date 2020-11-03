using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
