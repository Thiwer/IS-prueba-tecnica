using IS_prueba_tecnica.Application.Common.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public abstract partial class GenericRepository<T> where T : class
    {
        public virtual async Task<DataCollection<T>> GetPagedAsync(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            IQueryable<T> query;
            int originalPages;
            page = PreparePagedQuery(page, take, orderBy, predicate, include, out query, out originalPages);

            var result = new DataCollection<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }

        public virtual DataCollection<T> GetPaged(
            int page,
            int take,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {

            IQueryable<T> query;
            int originalPages;
            page = PreparePagedQuery(page, take, orderBy, predicate, include, out query, out originalPages);

            var result = new DataCollection<T>
            {
                Items = query.Skip(page).Take(take).ToList(),
                Total = query.Count(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }

        private int PreparePagedQuery(int page, int take, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, out IQueryable<T> query, out int originalPages)
        {
            query = _context.Set<T>().AsQueryable();
            originalPages = page;
            page--;

            if (page > 0)
            {
                page *= take;
            }

            query = PrepareQuery(query, predicate, include, orderBy);
            return page;
        }
    }
}
