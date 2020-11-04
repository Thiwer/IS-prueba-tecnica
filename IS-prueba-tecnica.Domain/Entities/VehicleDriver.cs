using IS_prueba_tecnica.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class VehicleDriver : AuditableEntity
    {
        public string VehicleMatricula { get; set; }
        public string DriverDni { get; set; }

        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }

        public ICollection<InfringementVehicleDriver> InfringementVehicleDrivers { get; set; }

        public VehicleDriver()
        {
            InfringementVehicleDrivers = new HashSet<InfringementVehicleDriver>();
        }
    }
}
