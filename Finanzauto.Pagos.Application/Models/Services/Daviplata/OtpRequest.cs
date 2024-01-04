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

        public OtpRequest(string typeDocument, string numberDocument, string notificationType)
        {
            TypeDocument = typeDocument;
            NumberDocument = numberDocument;
            NotificationType = notificationType;
        }
        public OtpRequest()
        {
            
        }
    }
}
