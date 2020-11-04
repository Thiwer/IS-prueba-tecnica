using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, string>
    {
        private readonly IUnitOfWork _uow;

        public CreateVehicleCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                // Check vehicle not exists
                var vehicle = await _uow.VehicleRepository.FirstOrDefaultAsync(v => v.Matricula == request.Matricula);
                if (vehicle != null)
                {
                    throw new VehicleExistsException(vehicle.Matricula);
                }

                // Check driver exists
                var driver = await _uow.DriverRepository.FirstOrDefaultAsync(d => d.Dni == request.Dni);
                if (driver == null)
                {
                    throw new DriverNotExistsException(request.Dni);
                }

                // Check driver does not have that car yet
                var vehicleDriver = await _uow.VehicleDriverRepository
                    .FirstOrDefaultAsync(vd => vd.VehicleMatricula == request.Matricula && vd.DriverDni == driver.Dni);

                if (vehicleDriver != null)
                {
                    throw new DriverHadThatVehicleException(driver.Dni, request.Matricula);
                }

                // Check driver dont have 10 cars yet
                var numCars = await _uow.VehicleDriverRepository.CountAsync(vd => vd.DriverDni == driver.Dni);
                if (numCars == 10)
                {
                    throw new VehiclesLimitException(driver.Dni);
                }

                // Retgister car
                vehicle = new Vehicle
                {
                    Matricula = request.Matricula,
                    Brand = request.Brand,
                    Model = request.Model
                };
                await _uow.VehicleRepository.AddAsync(vehicle);
                await _uow.SaveChangesAsync();

                // Register car relation
                vehicleDriver = new VehicleDriver
                {
                    DriverDni = driver.Dni,
                    VehicleMatricula = vehicle.Matricula,
                };
                await _uow.VehicleDriverRepository.AddAsync(vehicleDriver);
                await _uow.SaveChangesAsync();

                _uow.CommitTransaction();
                return vehicle.Matricula;
            }
            catch
            {
                _uow.RollbackTransaction();
                throw;
            }
        }
    }
}
