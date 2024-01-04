namespace Finanzauto.Pagos.Domain
{
    public partial class Param
    {
        public short Idparametro { get; set; }
        public string Parametro { get; set; } = null!;
        public string? Valor { get; set; }
    }
}