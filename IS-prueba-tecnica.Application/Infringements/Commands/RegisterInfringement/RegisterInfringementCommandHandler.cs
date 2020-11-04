using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Infringements.Commands.RegisterInfringement
{
    public class RegisterInfringementCommandHandler : IRequestHandler<RegisterInfringementCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public RegisterInfringementCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(RegisterInfringementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var infringement = await _uow.InfringementRepository.FirstOrDefaultAsync(i => i.Id == request.InfringementId);
                if (infringement == null)
                {
                    throw new InfringementNotExistsException(request.InfringementId);
                }

                var vehicle = await _uow.VehicleRepository.FirstOrDefaultAsync(v => v.Matricula == request.Matricula);
                if (vehicle == null)
                {
                    throw new VehicleNotExistsException(request.Matricula);
                }

                // Get first driver from a list of drivers of that car
                var driver = await _uow.DriverRepository.FirstOrDefaultAsync(
                    predicate: d => d.VehicleDrivers.Any(vh => vh.VehicleMatricula == request.Matricula),
                    orderBy: d => d.OrderByDescending(dr => dr.Created),
                    include: i => i.Include(i => i.VehicleDrivers).ThenInclude(a => a.Driver));

                driver.Points -= infringement.Points;

                _uow.DriverRepository.Update(driver);
                await _uow.SaveChangesAsync();

                var entity = new InfringementVehicleDriver
                {
                    DriverDni = driver.Dni,
                    InfringementId = request.InfringementId,
                    VehicleMatricula = request.Matricula
                };
                await _uow.InfringementVehicleDriverRepository.AddAsync(entity);
                await _uow.SaveChangesAsync();

                _uow.CommitTransaction();
                return infringement.Points;
            }
            catch
            {
                _uow.RollbackTransaction();
                throw;
            }
        }
    }
}
