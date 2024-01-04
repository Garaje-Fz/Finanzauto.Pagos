using Finanzauto.Helpers.Rest;
using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Models.Services.Signature;
using Finanzauto.Utils.Exceptions.Exceptions;
using Finanzauto.Utils.Serialization.Json.Extensions;
using Microsoft.Extensions.Options;

namespace Finanzauto.Pagos.Infrastructure.Services.Signature
{
    public class SignatureService : ISignatureService
    {
        private readonly SignatureSettings _settings;

        public SignatureService(IOptions<SignatureSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<ClientDataResponse> GetClientData(SignatureBaseRequest request)
        {
            request.SetConfiguration(_settings.IdApplication, _settings.Sign);

            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "DatosCliente")
                .WithJsonBody(request)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new BadRequestException($"Service signature:datosCliente response: {responseContent}");
            return responseContent.FromJson<ClientDataResponse>();
        }

        public async Task<LoanResponse> GetLoansInfo(SignatureBaseRequest request)
        {
            request.SetConfiguration(_settings.IdApplication, _settings.Sign);

            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "Prestamos")
                .WithJsonBody(request)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) throw new BadRequestException($"Service signature:prestamos response: {responseContent}");
            return responseContent.FromJson<LoanResponse>();
        }
    }
}
