using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class InfringementNotExistsException : Exception
    {
        public InfringementNotExistsException(string infringementId) : base($"Not exists an infringemen with id: {infringementId}") { }

        protected InfringementNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
