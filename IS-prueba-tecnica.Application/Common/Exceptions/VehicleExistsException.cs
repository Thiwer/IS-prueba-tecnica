using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class VehicleExistsException : Exception
    {
        public VehicleExistsException(string vehicleId) : base($"Exists a vehicle with id: {vehicleId}") { }

        protected VehicleExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
