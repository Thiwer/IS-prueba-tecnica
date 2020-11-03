using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public abstract partial class GenericRepository<T> where T : class
    {
        public virtual void Update(T t)
        {
            _context.Set<T>().Update(t);
        }

        public virtual void Update(IEnumerable<T> t)
        {
            _context.Set<T>().UpdateRange(t);
        }

        public virtual void AddOrUpdate(T t, params object[] keyValues)
        {
            var entity = _context.Set<T>().Find(keyValues);
            if (entity == null)
            {
                Add(t);
            }
            else
            {
                Update(t);
            }
        }

        public virtual async Task AddOrUpdateAsync(T t, params object[] keyValues)
        {
            var entity = await _context.Set<T>().FindAsync(keyValues);
            if (entity == null)
            {
                await AddAsync(t);
            }
            else
            {
                Update(t);
            }
        }

    }
}
