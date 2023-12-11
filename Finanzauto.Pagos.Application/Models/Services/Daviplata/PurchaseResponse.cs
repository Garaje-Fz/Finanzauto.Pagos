using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class PurchaseResponse
    {
        [JsonPropertyName("idSessionToken")]
        public string IdSessionToken { get; set; }

        [JsonPropertyName("fechaExpiracionToken")]
        public DateTimeOffset FechaExpiracionToken { get; set; }
    }
}
