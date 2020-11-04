using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class VehiclesLimitException : Exception
    {
        public VehiclesLimitException(string driverId) : base($"Driver with id: {driverId}, exceded the limit of cars") { }

        protected VehiclesLimitException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
