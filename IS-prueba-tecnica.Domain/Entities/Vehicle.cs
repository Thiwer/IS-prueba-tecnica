using IS_prueba_tecnica.Domain.Common;
using System.Collections.Generic;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        public string Matricula { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public ICollection<VehicleDriver> VehicleDrivers { get; private set; }

        public Vehicle()
        {
            VehicleDrivers = new HashSet<VehicleDriver>();
        }
    }
}
