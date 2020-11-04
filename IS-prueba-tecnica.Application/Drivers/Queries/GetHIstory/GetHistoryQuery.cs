using IS_prueba_tecnica.Application.ViewModels;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IS_prueba_tecnica.Application.Drivers.Queries.GetHIstory
{
    public class GetHistoryQuery : IRequest<IEnumerable<InfringementsDriverVm>>
{
        [JsonProperty("dni")]
        public string DriverDni { get; set; }
    }
}
