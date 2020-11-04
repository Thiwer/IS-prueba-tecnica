using IS_prueba_tecnica.Application.Common.Repository.Interfaces;
using IS_prueba_tecnica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Repository
{
    public interface IDriverRepository :
        ICreateRepository<Driver>,
        IPagedRepository<Driver>,
        IReadRepository<Driver>,
        IRemoveRepository<Driver>,
        IUpdateRepository<Driver>
    {
    }
}
