﻿using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class VehicleNotExistsException : Exception
    {
        public VehicleNotExistsException(string vehicleId) : base($"Not exists a vehicle with id: {vehicleId}") { }

        protected VehicleNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
