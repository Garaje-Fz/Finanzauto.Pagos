using MediatR;

namespace Finanzauto.Pagos.Application.Features.Pays.Commands
{
    public class CreatePay : IRequest
    {
        public int LoanNumber { get; set; }
        public string IdentificationType { get; set; }
        public int IdentificationNumber { get; set; }
        public decimal Value { get; set; }
        public short ChannelId { get; set; }
        public int PayOriginId { get; set; }
    }
}
