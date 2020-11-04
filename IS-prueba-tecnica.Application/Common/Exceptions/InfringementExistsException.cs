using System;
using System.Runtime.Serialization;

namespace IS_prueba_tecnica.Application.Common.Exceptions
{
    public class InfringementExistsException : Exception
    {
        public InfringementExistsException(int infringementId) : base($"Exists an infringemen with id: {infringementId}") { }

        protected InfringementExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
