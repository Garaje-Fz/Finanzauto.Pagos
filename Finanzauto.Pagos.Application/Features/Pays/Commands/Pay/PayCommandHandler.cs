using MediatR;

namespace Finanzauto.Pagos.Application.Features.Pays.Commands.Pay
{
    public class PayCommandHandler : IRequestHandler<PayCommand>
    {
        public Task Handle(PayCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
