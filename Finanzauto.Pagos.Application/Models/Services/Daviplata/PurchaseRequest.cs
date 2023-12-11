using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class PurchaseRequest
    {
        [JsonPropertyName("valor")]
        public string Valor { get; set; }

        [JsonPropertyName("numeroIdentificacion")]
        public string NumeroIdentificacion { get; set; }

        [JsonPropertyName("tipoDocumento")]
        public string TipoDocumento { get; set; }
    }
}
