using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class InfringementExistsException : Exception
    {
        public InfringementExistsException(string infringementId) : base($"Exists an infringemen with id: {infringementId}") { }

        protected InfringementExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
