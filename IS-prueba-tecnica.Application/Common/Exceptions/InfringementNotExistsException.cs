﻿using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class InfringementNotExistsException : Exception
    {
        public InfringementNotExistsException(int infringementId) : base($"Not exists an infringemen with id: {infringementId}") { }

        protected InfringementNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
