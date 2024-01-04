using Finanzauto.Pagos.Application.Contracts.Strategies;
using Finanzauto.Pagos.Domain;

namespace Finanzauto.Pagos.Application.Strategies.Pays
{
    public class PaysContext
    {
        private IPaysStrategy _strategy;
        public PaysContext()
        {
            
        }

        public PaysContext(IPaysStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetPayStrategy(IPaysStrategy paysStrategy)
        {
            _strategy = paysStrategy;
        }

        public async Task Pay(string documentType, string identificationNumber, decimal value, Payment payment)
        {
            await _strategy.Pay(documentType, identificationNumber, value, payment);
        }
    }
}
