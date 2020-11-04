using IS_prueba_tecnica.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class InfringementVehicleDriver : AuditableEntity
    {
        public int Id { get; set; }
        public string InfringementId { get; set; }
        public string DriverDni { get; set; }
        public string VehicleMatricula { get; set; }

        public Infringement Infringement { get; set; }
        public VehicleDriver VehicleDriver { get; set; }
    }
}
