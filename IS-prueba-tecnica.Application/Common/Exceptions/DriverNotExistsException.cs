using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class DriverNotExistsException: Exception
    {
        public DriverNotExistsException(string driverId) : base($"Not exists a driver with id: {driverId}") { }

        protected DriverNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
