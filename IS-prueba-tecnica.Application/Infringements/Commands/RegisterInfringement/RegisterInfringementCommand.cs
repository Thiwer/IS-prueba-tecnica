﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Infringements.Commands.RegisterInfringement
{
    public class RegisterInfringementCommand
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("matricula")]
        public string Matricula { get; set; }
    }
}
