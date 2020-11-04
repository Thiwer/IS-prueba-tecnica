using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Drivers.Queries.GetHIstory
{
    public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, IEnumerable<InfringementsDriverVm>>
    {
        private readonly IUnitOfWork _uow;

        public GetHistoryQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<InfringementsDriverVm>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var infringementsDriver = await _uow.InfringementVehicleDriverRepository.GetAllAsync(
                    predicate: ivd => ivd.DriverDni == request.DriverDni,
                    include: i => i.Include(i => i.VehicleDriver).ThenInclude(i => i.Driver)
                                   .Include(i => i.VehicleDriver).ThenInclude(i => i.Vehicle)
                                   .Include(i => i.Infringement)
                    );

                var infringements = infringementsDriver.Select(id => new InfringementsDriverVm { 
                    DriverName = id.VehicleDriver.Driver.Name,
                    VehicleMatricula = id.VehicleDriver.Vehicle.Matricula,
                    InfringementDescripction = id.Infringement.Description,
                    Date = id.Created
                });

                return infringements;
            }
            catch
            {
                throw;
            }
        }
    }
}
