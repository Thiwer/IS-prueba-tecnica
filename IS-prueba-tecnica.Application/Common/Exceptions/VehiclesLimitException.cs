﻿using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class VehiclesLimitException : Exception
    {
        public VehiclesLimitException(string vehicleId) : base($"Vehicle with id: {vehicleId}, exceded the limit of drivers") { }

        protected VehiclesLimitException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
