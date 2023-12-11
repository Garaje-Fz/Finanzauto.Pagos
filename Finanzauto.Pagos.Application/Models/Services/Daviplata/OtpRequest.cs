using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class OtpRequest
    {
        [JsonPropertyName("typeDocument")]
        public string TypeDocument { get; set; }

        [JsonPropertyName("numberDocument")]
        public string NumberDocument { get; set; }

        [JsonPropertyName("notificationType")]
        public string NotificationType { get; set; }
    }
}
