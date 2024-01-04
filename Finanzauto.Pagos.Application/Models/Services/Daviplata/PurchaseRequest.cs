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

        public PurchaseRequest(decimal value, string identificationNumber, string documentType)
        {
            Valor = value.ToString();
            NumeroIdentificacion = identificationNumber;
            TipoDocumento = documentType;
        }
        public PurchaseRequest()
        {
            
        }
    }
}
