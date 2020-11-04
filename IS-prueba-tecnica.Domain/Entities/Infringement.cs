using IS_prueba_tecnica.Domain.Common;
using System.Collections.Generic;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class Infringement : AuditableEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public ICollection<InfringementVehicleDriver> InfringementVehicleDrivers { get; set; }

        public Infringement()
        {
            InfringementVehicleDrivers = new HashSet<InfringementVehicleDriver>();
        }
    }
}
