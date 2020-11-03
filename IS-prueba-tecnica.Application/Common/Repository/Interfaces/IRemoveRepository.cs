using System.Collections.Generic;

namespace IS_prueba_tecnica.Application.Common.Repository.Interfaces
{
    public interface IRemoveRepository<in T> where T : class
    {
        void Remove(T t);

        void Remove(IEnumerable<T> t);
    }
}
