using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
        DateTime Now { get; }
    }
}
