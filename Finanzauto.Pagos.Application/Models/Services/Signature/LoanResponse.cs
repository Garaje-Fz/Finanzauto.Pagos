using Newtonsoft.Json;

namespace Finanzauto.Pagos.Application.Models.Services.Signature
{
    public class LoanResponse
    {
        [JsonProperty("Codigo")]
        public long Codigo { get; set; }

        [JsonProperty("Mensaje")]
        public object Mensaje { get; set; }

        [JsonProperty("Detalle")]
        public object Detalle { get; set; }

        [JsonProperty("Prestamos")]
        public List<Prestamo> Prestamos { get; set; }
    }

    public partial class Prestamo
    {
        [JsonProperty("Identificacion")]
        public long Identificacion { get; set; }

        [JsonProperty("NumeroPrestamo")]
        public long NumeroPrestamo { get; set; }

        [JsonProperty("DetalleGarantia")]
        public string DetalleGarantia { get; set; }

        [JsonProperty("PlacaVehiculo")]
        public string PlacaVehiculo { get; set; }

        [JsonProperty("ValorInicial")]
        public long ValorInicial { get; set; }

        [JsonProperty("NumeroCuotas")]
        public long NumeroCuotas { get; set; }

        [JsonProperty("SaldoCapital")]
        public long SaldoCapital { get; set; }

        [JsonProperty("CuotasPendientes")]
        public long CuotasPendientes { get; set; }

        [JsonProperty("CuotasPagadas")]
        public long CuotasPagadas { get; set; }

        [JsonProperty("CuotasMora")]
        public long CuotasMora { get; set; }

        [JsonProperty("DiasMora")]
        public long DiasMora { get; set; }

        [JsonProperty("ValorVencido")]
        public long ValorVencido { get; set; }

        [JsonProperty("FechaProximoPago")]
        public string FechaProximoPago { get; set; }

        [JsonProperty("ValorProximoPago")]
        public long ValorProximoPago { get; set; }

        [JsonProperty("CapitalProximoPago")]
        public long CapitalProximoPago { get; set; }

        [JsonProperty("InteresesProximoPago")]
        public long InteresesProximoPago { get; set; }

        [JsonProperty("SegurosProximoPago")]
        public long SegurosProximoPago { get; set; }

        [JsonProperty("MoraProximoPago")]
        public long MoraProximoPago { get; set; }

        [JsonProperty("CargosProximoPago")]
        public long CargosProximoPago { get; set; }

        [JsonProperty("FechaUltimoPago")]
        public string FechaUltimoPago { get; set; }

        [JsonProperty("ValorUltimoPago")]
        public long ValorUltimoPago { get; set; }

        [JsonProperty("CapitalUltimoPago")]
        public long CapitalUltimoPago { get; set; }

        [JsonProperty("InteresesUltimoPago")]
        public long InteresesUltimoPago { get; set; }

        [JsonProperty("SegurosUltimoPago")]
        public long SegurosUltimoPago { get; set; }

        [JsonProperty("MoraUltimoPago")]
        public long MoraUltimoPago { get; set; }

        [JsonProperty("CargosUltimoPago")]
        public long CargosUltimoPago { get; set; }

        [JsonProperty("EstadoCredito")]
        public string EstadoCredito { get; set; }

        [JsonProperty("EstadoPago")]
        public string EstadoPago { get; set; }

        [JsonProperty("IndicadorRenovacion")]
        public long IndicadorRenovacion { get; set; }

        [JsonProperty("OcultarInfoCredito")]
        public bool OcultarInfoCredito { get; set; }
    }
}
