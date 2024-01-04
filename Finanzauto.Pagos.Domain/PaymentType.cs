namespace Finanzauto.Pagos.Domain
{
    public partial class PaymentType
    {
        public short IdTipoPago { get; set; }
        public string? TipoPago { get; set; }
        public decimal? Valor { get; set; }
        public bool Activo { get; set; }
    }
}