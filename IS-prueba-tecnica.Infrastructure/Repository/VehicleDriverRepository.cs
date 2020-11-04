using IS_prueba_tecnica.Application.Common.Interfaces;
using IS_prueba_tecnica.Application.Common.Repository;
using IS_prueba_tecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    class VehicleDriverRepository : GenericRepository<VehicleDriver>, IVehicleDriverRepository
    {
        public VehicleDriverRepository(IPruebaTecnicaDbContext context) : base(context)
        {
        }
    }
}
