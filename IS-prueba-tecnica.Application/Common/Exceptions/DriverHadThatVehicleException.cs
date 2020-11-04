using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class DriverHadThatVehicleException : Exception
    {
        public DriverHadThatVehicleException(string driverId, string vehicleId) : base($"Driver with id: {driverId}, have a car with matricula: {vehicleId}") { }

        protected DriverHadThatVehicleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
