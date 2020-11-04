using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommand: IRequest<string>
    {
        [JsonProperty("dni")]
        public string Dni { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subnames")]
        public string Subnames { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }
    }
}
