using Finanzauto.Pagos.Application.Contracts.Repositories;
using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Contracts.Strategies;
using Finanzauto.Pagos.Application.Models.Services.Daviplata;
using Finanzauto.Pagos.Domain;

namespace Finanzauto.Pagos.Application.Strategies.Pays
{
    public class DaviplataPayStrategy : IPaysStrategy
    {
        private readonly IDaviplataService _daviplataService;
        private readonly IUnitOfWork _unitOfWork;

        private const string NOTIFICATION_TYPE = "API_DAVIPLATA";
        private const string ID_COMERCIO = "0010203040";
        private const string ID_TERMINAL = "ESB10934";

        public DaviplataPayStrategy(IDaviplataService daviplataService, IUnitOfWork unitOfWork)
        {
            _daviplataService = daviplataService;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Pay(string documentType, string identificationNumber, decimal value, Payment payment)
        {
            //Generación del token
            var token = await _daviplataService.GetToken();

            //Validación del saldo del usuario
            var purchaseRequest = new PurchaseRequest(value, identificationNumber, documentType);
            var purchaseResponse = await _daviplataService.Purchase(purchaseRequest, token);

            //Validación de identidad OTP
            var otpRequest = new OtpRequest(documentType, identificationNumber, NOTIFICATION_TYPE);
            await _daviplataService.Otp(otpRequest, token);

            //Almacenar las variables (idSessionToken)
            await SavePayInfo(purchaseResponse, payment);

            return true;
        }

        private async Task SavePayInfo(PurchaseResponse purchaseResponse, Payment payment)
        {
            payment.DaviplataIdSessionToken = purchaseResponse.IdSessionToken;
            await _unitOfWork.Commit();
        }

        public async Task Confirm(string otp, string idSessionToken)
        {
            //TODO: Id transaccion (numero de transacción del día)
            var idTransaccion = 1;

            //Generación del token
            var token = await _daviplataService.GetToken();

            //Confirmacion de la compra
            var confirmReq = new ConfirmRequest(otp, idSessionToken, ID_COMERCIO, ID_TERMINAL, idTransaccion);
            await _daviplataService.Confirm(confirmReq, token);
        }
    }
}
