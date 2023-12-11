using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class OtpResponse
    {
        [JsonPropertyName("otp")]
        public string Otp { get; set; }
    }
}
