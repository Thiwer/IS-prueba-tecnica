using IS_prueba_tecnica.Domain.Common;
using System.Collections.Generic;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class Driver : AuditableEntity
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Subnames { get; set; }
        public int Points { get; set; }

        public ICollection<VehicleDriver> VehicleDrivers { get; set; }

        public Driver()
        {
            VehicleDrivers = new HashSet<VehicleDriver>();
        }
    }
}
