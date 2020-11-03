using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.Repository.Interfaces
{
    public interface IUpdateRepository<in T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);

        void AddOrUpdate(T t, params object[] keyValues);
        Task AddOrUpdateAsync(T t, params object[] keyValues);
    }
}
