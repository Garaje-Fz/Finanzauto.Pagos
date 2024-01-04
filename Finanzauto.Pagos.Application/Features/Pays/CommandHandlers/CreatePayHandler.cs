using Finanzauto.Pagos.Application.Contracts.Repositories;
using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Features.Pays.Commands;
using Finanzauto.Pagos.Application.Models.Services.Signature;
using Finanzauto.Pagos.Application.Specifications.Pays;
using Finanzauto.Pagos.Application.Strategies.Pays;
using Finanzauto.Pagos.Domain;
using Finanzauto.Utils.Exceptions.Exceptions;
using MediatR;

namespace Finanzauto.Pagos.Application.Features.Pays.CommandHandlers
{
    public class CreatePayHandler : IRequestHandler<CreatePay>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDaviplataService _daviplataService;
        private readonly ISignatureService _signatureService;

        private const int PAY_TYPE = 1;

        public CreatePayHandler(
            IUnitOfWork unitOfWork,
            IDaviplataService daviplataService,
            ISignatureService signatureService)
        {
            _unitOfWork = unitOfWork;
            _daviplataService = daviplataService;
            _signatureService = signatureService;
        }

        public async Task Handle(CreatePay request, CancellationToken cancellationToken)
        {
            //validar
            await ValidatePay(request);
            //insertar en bd
            var payment = await SavePay(request);
            //llamar servicios correspondientes mediante strategy
            await CallStrategies(request, payment);
        }

        private async Task CallStrategies(CreatePay request, Payment payment)
        {
            switch (request.ChannelId)
            {
                //Daviplata
                case 1:
                    var strategyContext = new PaysContext();
                    strategyContext.SetPayStrategy(new DaviplataPayStrategy(_daviplataService, _unitOfWork));
                    await strategyContext.Pay(request.IdentificationType, request.IdentificationNumber.ToString(), request.Value, payment);
                    break;
                default:
                    break;
            }
        }

        private async Task<Payment> SavePay(CreatePay request)
        {
            var payment = new Payment(
                request.IdentificationNumber,
                request.LoanNumber,
                PAY_TYPE,
                request.Value,
                request.PayOriginId,
                request.ChannelId);
            _unitOfWork.GetRepository<Payment>().Add(payment);
            await _unitOfWork.Commit();
            return payment;
        }

        private async Task ValidatePay(CreatePay command)
        {
            var loanInfo = await GetLoanInfo(command.IdentificationNumber, command.LoanNumber);
            var pays = await GetTodaysPayments(command);
            var paySpecification = new PayValidationSpecification(loanInfo.ValorProximoPago, pays);
            paySpecification.IsSatisfiedBy(command);
        }

        private async Task<List<Payment>> GetTodaysPayments(CreatePay command)
        {
            var pays = await _unitOfWork.GetRepository<Payment>().Find(p =>
                //p.NumeroPrestamo == command.LoanNumber && 
                p.Identificacion == command.IdentificationNumber &&
                p.FechaTransaccion.Date == DateTime.Now.Date);
            return pays.ToList();
        }

        private async Task<Prestamo> GetLoanInfo(long identificationNumber, long loanNumber)
        {
            var loansInfo = await _signatureService.GetLoansInfo(new SignatureBaseRequest(identificationNumber));
            var loanInfo = loansInfo.Prestamos.FirstOrDefault(x => x.NumeroPrestamo == loanNumber);
            if (loanInfo == null) throw new BadRequestException("No se encontró información del préstamo");
            return loanInfo;
        }
    }
}
