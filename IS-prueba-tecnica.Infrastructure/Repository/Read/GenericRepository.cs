using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public abstract partial class GenericRepository<T> where T : class
    {
        public virtual IEnumerable<T> GetAll(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy, take);

            return query.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? take = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy, take);

            return await query.ToListAsync();
        }

        public virtual T Single(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return query.Single();
        }

        public virtual async Task<T> SingleAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return await query.SingleAsync();
        }

        public virtual T SingleOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return query.SingleOrDefault();
        }

        public virtual async Task<T> SingleOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include);

            return await query.SingleOrDefaultAsync();
        }

        public virtual T Find(params object[] keyValues)
        {
            var t = _context.Set<T>().Find(keyValues);
            return t;
        }
        public virtual async Task<T> FindAsync(params object[] keyValues)
        {
            var t = await _context.Set<T>().FindAsync(keyValues);
            return t;
        }

        public virtual T First(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return query.First();
        }

        public virtual async Task<T> FirstAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return await query.FirstAsync();
        }

        public virtual T FirstOrDefault(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return query.FirstOrDefault();
        }

        public virtual async Task<T> FirstOrDefaultAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate, include, orderBy);

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<decimal?> SumAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await ((IQueryable<decimal?>)query).SumAsync();
        }

        public virtual decimal? Sum(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return ((IQueryable<decimal?>)query).Sum();
        }

        public virtual async Task<int> CountAsync(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return await query.CountAsync();
        }

        public virtual int Count(
            Expression<Func<T, bool>> predicate = null
        )
        {
            var query = _context.Set<T>().AsQueryable();

            query = PrepareQuery(query, predicate);

            return query.Count();
        }
    }
}
