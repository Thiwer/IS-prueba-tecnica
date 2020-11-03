using System.Collections.Generic;
using System.Threading.Tasks;

namespace IS_prueba_tecnica.Application.Common.Repository.Interfaces
{
    public interface ICreateRepository<in T> where T : class
    {
        void Add(T t);
        void Add(IEnumerable<T> t);

        Task AddAsync(T t);
        Task AddAsync(IEnumerable<T> t);
    }
}
