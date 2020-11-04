using MediatR;
using Newtonsoft.Json;

namespace IS_prueba_tecnica.Application.Infringements.Commands.RegisterInfringement
{
    public class RegisterInfringementCommand :IRequest<int>
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("matricula")]
        public string Matricula { get; set; }

        [JsonProperty("infringementId")]
        public int InfringementId { get; set; }
    }
}
