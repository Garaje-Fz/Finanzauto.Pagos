using Finanzauto.Pagos.Application.Contracts.Specifications;
using Finanzauto.Pagos.Application.Features.Pays.Commands;
using Finanzauto.Pagos.Domain;
using Finanzauto.Utils.Exceptions.Exceptions;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Finanzauto.Pagos.Application.Specifications.Pays
{
    public class PayValidationSpecification : ISpecification<CreatePay>
    {
        private readonly decimal _minValueToPay;
        private readonly decimal _maxFeesToPay;
        private readonly decimal _regularFeePay;

        private readonly List<Payment> _pays = new List<Payment>();

        public PayValidationSpecification(
            decimal regularFeePay,
            List<Payment> pays)
        {
            var ToDecimal = (string value) => decimal.Parse(value);
            var GetConfig = (string key) => ConfigurationManager.GetSection(key).ToString();

            _minValueToPay = ToDecimal(GetConfig("PayValidationSettings:MinValueToPay"));
            _maxFeesToPay = ToDecimal(GetConfig("PayValidationSettings:MaxFeesToPay"));
            _regularFeePay = regularFeePay;
            _pays = pays;
        }

        public bool IsSatisfiedBy(CreatePay command)
        {
            var ToCOP = (decimal value) => $"COP ${value.ToString("{c0}")}";

            decimal maxDailyPay = _regularFeePay * _maxFeesToPay;

            if (command.Value < _minValueToPay)
                throw new BadRequestException($"El pago no puede ser inferior a {ToCOP(_minValueToPay)}");
            if (command.Value > _minValueToPay && command.Value > maxDailyPay)
                throw new BadRequestException($"El pago no puede ser mayor a {ToCOP(maxDailyPay)}");
            if (ExceedsTheDailyAmount(maxDailyPay))
                throw new BadRequestException(@$"Ha excedido el valor límite de pago diario en la zona transaccional de Finanzauto.
                        Intente de nuevo más tarde o comuníquese con nosotros");
            return true;
        }

        private bool ExceedsTheDailyAmount(decimal maxDailyPay)
        {
            if (!_pays.Any()) return false;
            var totalPaidToday = _pays.Sum(x => x.ValorWeb);
            if (totalPaidToday < maxDailyPay) return false;
            return true;

        }
    }
}
