using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class DriverExistsException : Exception
    {
        public DriverExistsException(string driverId) : base($"Exists a driver with id: {driverId}") { }

        protected DriverExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
