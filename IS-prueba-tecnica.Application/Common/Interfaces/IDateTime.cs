using System;

namespace IS_prueba_tecnica.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
    }
}
