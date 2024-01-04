using Finanzauto.Pagos.Domain;

namespace Finanzauto.Pagos.Application.Contracts.Strategies
{
    public interface IPaysStrategy
    {
        Task<bool> Pay(string documentType, string identificationNumber, decimal value, Payment payment);
        Task Confirm(string otp, string idSessionToken);
    }
}
