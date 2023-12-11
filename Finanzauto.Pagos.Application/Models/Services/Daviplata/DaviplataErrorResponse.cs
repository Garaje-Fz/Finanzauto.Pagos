using System.Text.Json.Serialization;

namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class DaviplataErrorResponse
    {
        [JsonPropertyName("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
