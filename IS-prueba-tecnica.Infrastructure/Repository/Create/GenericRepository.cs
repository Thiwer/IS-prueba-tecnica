using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public abstract partial class GenericRepository<T> where T : class
    {
        public virtual void Add(T t)
        {
            _context.Set<T>().Add(t);
        }

        public virtual void Add(IEnumerable<T> t)
        {
            _context.Set<T>().AddRange(t);
        }

        public virtual async Task AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
        }

        public virtual async Task AddAsync(IEnumerable<T> t)
        {
            await _context.Set<T>().AddRangeAsync(t);
        }
    }
}
