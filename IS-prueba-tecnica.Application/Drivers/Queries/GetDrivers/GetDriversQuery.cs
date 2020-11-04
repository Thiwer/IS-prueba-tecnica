using IS_prueba_tecnica.Application.ViewModels;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Drivers.Queries.GetDrivers
{
    public class GetDriversQuery : IRequest<IEnumerable<DriverVm>>
    {
        [JsonProperty("numDrivers")]
        public int NumDrivers { get; set; }
    }
}
