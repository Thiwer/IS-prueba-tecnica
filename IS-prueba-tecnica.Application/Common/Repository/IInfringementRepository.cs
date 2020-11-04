using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using IS_prueba_tecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Repository
{
    public interface IInfringementRepository :
        ICreateRepository<Infringement>,
        IPagedRepository<Infringement>,
        IReadRepository<Infringement>,
        IRemoveRepository<Infringement>,
        IUpdateRepository<Infringement>
    {
    }
}
