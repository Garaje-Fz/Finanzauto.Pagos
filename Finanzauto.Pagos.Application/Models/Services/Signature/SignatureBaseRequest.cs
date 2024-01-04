using Newtonsoft.Json;

namespace Finanzauto.Pagos.Application.Models.Services.Signature
{
    public class SignatureBaseRequest
    {
        [JsonProperty("IdAplicativo")]
        public int IdAplicativo { get; private set; }

        [JsonProperty("Firma")]
        public string Firma { get; private set; }

        [JsonProperty("Identificacion")]
        public long Identificacion { get; set; }

        public SignatureBaseRequest(long identificacion)
        {
            Identificacion = identificacion;
        }
        public void SetConfiguration(int idApplicativo, string firma)
        {
            IdAplicativo = idApplicativo;
            Firma = firma;
        }
        public SignatureBaseRequest()
        {
            
        }
    }
}
