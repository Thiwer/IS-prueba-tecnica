using IS_prueba_tecnica.Application.Common.Exceptions;
using IS_prueba_tecnica.Application.Common.UnitOfWork;
using IS_prueba_tecnica.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Infringements.Commands.CreateInfringement
{
    public class CreateInfringementCommandHandler : IRequestHandler<CreateInfringementCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public CreateInfringementCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(CreateInfringementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _uow.BeginTransactionAsync();

                var infringement = await _uow.InfringementRepository.FirstOrDefaultAsync(i => i.Id == request.Id);
                if (infringement != null)
                {
                    throw new InfringementExistsException(infringement.Id);
                }

                infringement = new Infringement
                {
                    Id = request.Id,
                    Description = request.Description,
                    Points = request.Id
                };
                await _uow.InfringementRepository.AddAsync(infringement);
                await _uow.SaveChangesAsync();

                _uow.CommitTransaction();
                return infringement.Id;
            }
            catch
            {
                _uow.RollbackTransaction();
                throw;
            }
        }
    }
}
