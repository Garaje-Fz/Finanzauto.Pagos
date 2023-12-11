using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class ConfirmRequest
    {
        [JsonPropertyName("otp")]
        public string Otp { get; set; }

        [JsonPropertyName("idSessionToken")]
        public string IdSessionToken { get; set; }

        [JsonPropertyName("idComercio")]
        public string IdComercio { get; set; }

        [JsonPropertyName("idTerminal")]
        public string IdTerminal { get; set; }

        [JsonPropertyName("idTransaccion")]
        public long IdTransaccion { get; set; }
    }
}
