using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.ViewModels
{
    public class DriverVm
    {
        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subNames")]
        public string Subnames { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }
    }
}
