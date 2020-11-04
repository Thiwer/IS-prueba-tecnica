using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class DriverNotExistsException : Exception
    {
        public DriverNotExistsException(string driverId) : base($"Not exists a driver with id: {driverId}") { }

        protected DriverNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
