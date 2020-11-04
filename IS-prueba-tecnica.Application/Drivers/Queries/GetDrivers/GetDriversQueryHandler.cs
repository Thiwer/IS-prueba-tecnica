using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Drivers.Queries.GetDrivers
{
    public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, IEnumerable<DriverVm>>
    {
        private readonly IUnitOfWork _uow;

        public GetDriversQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<DriverVm>> Handle(GetDriversQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var drivers = await _uow.DriverRepository.GetAllAsync(take: request.NumDrivers);

                var driversVm = drivers.Select(d => new DriverVm
                {
                    Dni = d.Dni,
                    Name = d.Name,
                    Subnames = d.Subnames,
                    Points = d.Points
                });

                return driversVm;
            }
            catch
            {
                throw;
            }
        }
    }
}
