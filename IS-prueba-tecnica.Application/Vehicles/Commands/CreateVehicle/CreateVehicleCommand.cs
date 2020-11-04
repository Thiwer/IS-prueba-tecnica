using Newtonsoft.Json;

namespace IS_prueba_tecnica.Application.Vehicles.Commands.CreateVehicle
{
    public class CreateVehicleCommand
    {

        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("dni")]
        public int Dni { get; set; }
    }
}
