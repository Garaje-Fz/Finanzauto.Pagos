namespace Finanzauto.Pagos.Domain
{
    public class Payment
    {
        public int Idpago { get; set; }
        public long Identificacion { get; set; }
        public int NumeroPrestamo { get; set; }
        public int IdtipoPago { get; set; }
        public decimal ValorWeb { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public decimal? ValorPayu { get; set; }
        public string? StatePolPayu { get; set; }
        public string? ResponseMessagePolPayu { get; set; }
        public string? ResponseCodePolPayu { get; set; }
        public string? ReferencePolPayu { get; set; }
        public DateTime? FechaValidacionPayu { get; set; }
        public bool SincronizadoSignature { get; set; }
        public DateTime? FechaSincronizacion { get; set; }
        public string? DatosRespuestaPayU { get; set; }
        public int? IdtipoOrigen { get; set; }
        public short MedioPago { get; set; }
        public string? CodEstadoRespuestaSignature { get; set; }
        public bool? EstadoLectura { get; set; }
        public string DaviplataIdSessionToken { get; set; }
        public virtual PaymentOrigin? IdtipoOrigenNavigation { get; set; }

        public Payment(int idpago, long identificacion, int numeroPrestamo, int idtipoPago, decimal valorWeb, DateTime fechaTransaccion, decimal? valorPayu, string? statePolPayu, string? responseMessagePolPayu, string? responseCodePolPayu, string? referencePolPayu, DateTime? fechaValidacionPayu, bool sincronizadoSignature, DateTime? fechaSincronizacion, string? datosRespuestaPayU, int? idtipoOrigen, short medioPago, string? codEstadoRespuestaSignature, bool? estadoLectura, string daviplataIdSessionToken, PaymentOrigin? idtipoOrigenNavigation)
        {
            Idpago = idpago;
            Identificacion = identificacion;
            NumeroPrestamo = numeroPrestamo;
            IdtipoPago = idtipoPago;
            ValorWeb = valorWeb;
            FechaTransaccion = fechaTransaccion;
            ValorPayu = valorPayu;
            StatePolPayu = statePolPayu;
            ResponseMessagePolPayu = responseMessagePolPayu;
            ResponseCodePolPayu = responseCodePolPayu;
            ReferencePolPayu = referencePolPayu;
            FechaValidacionPayu = fechaValidacionPayu;
            SincronizadoSignature = sincronizadoSignature;
            FechaSincronizacion = fechaSincronizacion;
            DatosRespuestaPayU = datosRespuestaPayU;
            IdtipoOrigen = idtipoOrigen;
            MedioPago = medioPago;
            CodEstadoRespuestaSignature = codEstadoRespuestaSignature;
            EstadoLectura = estadoLectura;
            DaviplataIdSessionToken = daviplataIdSessionToken;
            IdtipoOrigenNavigation = idtipoOrigenNavigation;
        }

        public Payment(int identification, int loanId, int payTypeId, decimal @value, int originTypeId, short payMethod)
        {
            Identificacion = identification;
            NumeroPrestamo = loanId;
            IdtipoPago = payTypeId;
            ValorWeb = @value;
            IdtipoOrigen = originTypeId;
            MedioPago = payMethod;
        }

        public Payment()
        {

        }
    }
}