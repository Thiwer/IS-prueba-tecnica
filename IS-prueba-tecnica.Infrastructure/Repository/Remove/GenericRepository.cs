using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Infrastructure.Repository
{
    public abstract partial class GenericRepository<T> where T : class
    {
        public virtual void Remove(T t)
        {
            _context.Set<T>().Remove(t);
        }

        public virtual void Remove(IEnumerable<T> t)
        {
            _context.Set<T>().RemoveRange(t);
        }
    }
}
