using Newtonsoft.Json;

namespace Finanzauto.Pagos.Application.Models.Services.Signature
{
    public class ClientDataResponse
    {
        [JsonProperty("CodigoMensaje")]
        public long CodigoMensaje { get; set; }

        [JsonProperty("Mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("Detalle")]
        public object Detalle { get; set; }

        [JsonProperty("NumeroId")]
        public long NumeroId { get; set; }

        [JsonProperty("PrimerApellido")]
        public string PrimerApellido { get; set; }

        [JsonProperty("SegundoApellido")]
        public string SegundoApellido { get; set; }

        [JsonProperty("Nombre")]
        public string Nombre { get; set; }

        [JsonProperty("NombreCompleto")]
        public string NombreCompleto { get; set; }

        [JsonProperty("MailPersonal")]
        public string MailPersonal { get; set; }

        [JsonProperty("DireccionDomilicio")]
        public string DireccionDomilicio { get; set; }

        [JsonProperty("CiudadDomilicio")]
        public string CiudadDomilicio { get; set; }

        [JsonProperty("BarrioDomilicio")]
        public string BarrioDomilicio { get; set; }

        [JsonProperty("TelefonoCelular")]
        public string TelefonoCelular { get; set; }

        [JsonProperty("TelefonoDomicilio")]
        public string TelefonoDomicilio { get; set; }

        [JsonProperty("NombreEmpresaEmpleo")]
        public string NombreEmpresaEmpleo { get; set; }

        [JsonProperty("MailEmpleo")]
        public string MailEmpleo { get; set; }

        [JsonProperty("DireccionEmpleo")]
        public string DireccionEmpleo { get; set; }

        [JsonProperty("TipoDocumento")]
        public string TipoDocumento { get; set; }

        [JsonProperty("DepartamentoCiudad")]
        public string DepartamentoCiudad { get; set; }

        [JsonProperty("CodigoDepartamentoCiudad")]
        public string CodigoDepartamentoCiudad { get; set; }

        [JsonProperty("CiudadEmpleo")]
        public string CiudadEmpleo { get; set; }

        [JsonProperty("BarrioEmpleo")]
        public string BarrioEmpleo { get; set; }

        [JsonProperty("TelefonoEmpleo")]
        public string TelefonoEmpleo { get; set; }

        [JsonProperty("TipoPersona")]
        public string TipoPersona { get; set; }
    }
}
