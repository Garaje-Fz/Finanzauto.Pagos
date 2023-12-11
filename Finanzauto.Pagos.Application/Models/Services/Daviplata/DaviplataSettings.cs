namespace Finanzauto.Pagos.Application.Models.Services.Daviplata
{
    public class DaviplataSettings
    {
        public string UrlBase { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
        public string[] CertificatePaths { get; set; }
    }
}
