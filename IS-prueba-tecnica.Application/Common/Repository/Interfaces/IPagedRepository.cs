﻿using IS_prueba_tecnica.Application.Common.Repository.Models;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.Repository.Interfaces
{
    public interface IPagedRepository<T> where T : class
    {
        Task<DataCollection<T>> GetPagedAsync(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );

        DataCollection<T> GetPaged(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        );
    }
}
