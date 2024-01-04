namespace Finanzauto.Pagos.Domain
{
    public partial class PaymentOrigin
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<Payment> FzPagosOnLines { get; set; } = new List<Payment>();
    }
}