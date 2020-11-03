using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Domain.Entities
{
    public class Vehicle
    {
        public string Matricula { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public ICollection<Driver> Drivers { get; private set; }

        public Vehicle()
        {
            Drivers = new HashSet<Driver>();
        }
    }
}
