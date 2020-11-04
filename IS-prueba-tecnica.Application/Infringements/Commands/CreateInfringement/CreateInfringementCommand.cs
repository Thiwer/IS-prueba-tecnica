using MediatR;
using Newtonsoft.Json;

namespace IS_prueba_tecnica.Application.Infringements.Commands.CreateInfringement
{
    public class CreateInfringementCommand : IRequest<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }
    }
}
