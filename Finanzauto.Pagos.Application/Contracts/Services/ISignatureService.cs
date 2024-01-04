using Finanzauto.Pagos.Application.Models.Services.Signature;

namespace Finanzauto.Pagos.Application.Contracts.Services
{
    public interface ISignatureService
    {
        Task<LoanResponse> GetLoansInfo(SignatureBaseRequest request);
        Task<ClientDataResponse> GetClientData(SignatureBaseRequest request);
    }
}
