using Finanzauto.Helpers.Rest;
using Finanzauto.Pagos.Application.Contracts.Services;
using Finanzauto.Pagos.Application.Models.Services.Daviplata;
using Finanzauto.Utils.Exceptions.Exceptions;
using Finanzauto.Utils.Serialization.Json.Extensions;
using Microsoft.Extensions.Options;

namespace Finanzauto.Pagos.Infrastructure.Services.Daviplata
{
    public class DaviplataService : IDaviplataService
    {
        private readonly DaviplataSettings _settings;

        public DaviplataService(IOptions<DaviplataSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<string> GetToken()
        {
            var formData = new Dictionary<string, string> {
                { "grant_type", _settings.GrantType },
                { "client_id", _settings.ClientId },
                { "client_secret", _settings.ClientSecret },
                { "scope", _settings.Scope }
            };
            var certificates = GetCertificatePaths();
            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "oauth2Provider/type1/v1/token")
                .WithCertificates(certificates)
                .WithFormData(formData)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            if (!response.IsSuccessStatusCode) HandleErrors(await response.Content.ReadAsStringAsync(), "daviplata:token");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.FromJson<AuthResponse>().AccessToken;
        }

        public async Task<PurchaseResponse> Purchase(PurchaseRequest request, string token)
        {
            var certificates = GetCertificatePaths();
            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "daviplata/v1/compra")
                .WithAuth(AuthenticationTypesEnum.BearerToken, token)
                .AddHeader("x-ibm-client-id", _settings.ClientId)
                .WithCertificates(certificates)
                .WithJsonBody(request)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            if (!response.IsSuccessStatusCode) HandleErrors(await response.Content.ReadAsStringAsync(), "daviplata:purchase");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.FromJson<PurchaseResponse>();
        }

        public async Task<OtpResponse> Otp(OtpRequest request, string token)
        {
            var certificates = GetCertificatePaths();
            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "otpSec/v1/read")
                .WithAuth(AuthenticationTypesEnum.BearerToken, token)
                .AddHeader("x-ibm-client-id", _settings.ClientId)
                .WithCertificates(certificates)
                .WithJsonBody(request)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            if (!response.IsSuccessStatusCode) HandleErrors(await response.Content.ReadAsStringAsync(), "daviplata:otp");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.FromJson<OtpResponse>();
        }

        public async Task<ConfirmResponse> Confirm(ConfirmRequest request, string token)
        {
            var certificates = GetCertificatePaths();
            var config = new RestConfigurationBuilder(HttpMethod.Post)
                .WithUrl(_settings.UrlBase, "daviplata/v1/confirmarCompra")
                .WithAuth(AuthenticationTypesEnum.BearerToken, token)
                .AddHeader("x-ibm-client-id", _settings.ClientId)
                .WithCertificates(certificates)
                .WithJsonBody(request)
                .Build();

            var response = await RestHelper.MakeRequest(config);
            if (!response.IsSuccessStatusCode) HandleErrors(await response.Content.ReadAsStringAsync(), "daviplata:confirm");
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.FromJson<ConfirmResponse>();
        }

        private List<string> GetCertificatePaths()
            => _settings.CertificatePaths.ToList();

        private void HandleErrors(string error, string serviceName)
        {
            var responseError = error.FromJson<DaviplataErrorResponse>();
            throw new BadRequestException($"Service {serviceName} response: {responseError.ErrorMessage}");
        }
    }
}
