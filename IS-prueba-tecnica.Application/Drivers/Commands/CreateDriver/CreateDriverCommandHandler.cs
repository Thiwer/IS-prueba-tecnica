using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, string>
    {
        private readonly IUnitOfWork _uow;

        public CreateDriverCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<string> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var driver = await _uow.DriverRepository.FirstOrDefaultAsync(d => d.Dni == request.Dni);
                if (driver != null)
                {
                    throw new DriverExistsException(driver.Dni);
                }

                driver = new Driver
                {
                    Dni = request.Dni,
                    Name = request.Name,
                    Subnames = request.Subnames,
                    Points = request.Points
                };
                await _uow.DriverRepository.AddAsync(driver);
                await _uow.SaveChangesAsync();

                _uow.CommitTransaction();
                return driver.Dni;
            }
            catch
            {
                _uow.RollbackTransaction();
                throw;
            }
        }
    }
}
