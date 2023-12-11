using Finanzauto.Pagos.Application.Models.Services.Daviplata;

namespace Finanzauto.Pagos.Application.Contracts.Services
{
    public interface IDaviplataService
    {
        Task<string> GetToken();
        Task<PurchaseResponse> Purchase(PurchaseRequest request, string token);
        Task<OtpResponse> Otp(OtpRequest request, string token);
        Task<ConfirmResponse> Confirm(ConfirmRequest request, string token);
    }
}
