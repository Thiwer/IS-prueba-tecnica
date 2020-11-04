using MediatR;
using Newtonsoft.Json;

namespace IS_prueba_tecnica.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand :IRequest<string>
    {

        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("marca")]
        public string Brand { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("dni")]
        public string Dni{ get; set; }
    }
}
