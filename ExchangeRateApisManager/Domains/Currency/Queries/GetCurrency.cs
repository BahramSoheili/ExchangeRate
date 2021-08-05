using Core.Queries;
using ExchangeRateApisManager.Domains.Currency.ValueObjects;
using ExchangeRateApisManager.Domains.Currency.View;

namespace ExchangeRateApisManager.Domains.Currency.Queries
{   
    public class GetCurrency : IQuery<double>
    {
        public CurrencyInfo Data { get; }

        public GetCurrency(CurrencyInfo data)
        {
            Data = data;
        }
    }
}



