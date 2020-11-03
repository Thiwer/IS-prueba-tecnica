using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Repository.Interfaces
{
    public interface IRemoveRepository<in T> where T : class
    {
        void Remove(T t);

        void Remove(IEnumerable<T> t);
    }
}
