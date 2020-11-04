using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using IS_prueba_tecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Repository
{
    public interface IVehicleDriverRepository :
        ICreateRepository<VehicleDriver>,
        IPagedRepository<VehicleDriver>,
        IReadRepository<VehicleDriver>,
        IRemoveRepository<VehicleDriver>,
        IUpdateRepository<VehicleDriver>
    {
    }
}
