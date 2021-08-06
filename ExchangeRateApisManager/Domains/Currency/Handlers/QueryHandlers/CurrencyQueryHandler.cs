using Core.Queries;
using ExchangeRateApisManager.Domains.Currency.Queries;
using ExchangeRateApisManager.Domains.Currency.ValueObjects;
using ExchangeRateApisManager.Domains.Currency.View;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeRateApisManager.Domains.Currency.Handlers.QueryHandlers
{
    public class CurrencyQueryHandler : IQueryHandler<GetCurrency, double>
    {
        private readonly string _URLString;
        private readonly List<string> currencies;
        public CurrencyQueryHandler(IConfiguration configuration)
        {
            _URLString = configuration.GetSection("CurrencyApiSettings").GetSection("Url").Value;
            currencies = new List<string>()
            { "AED","ARS","AUD","BGN","BRL","BSD","CAD","CHF","CLP","EGP","EUR","GBP","JPY","AED","AED" }; 
        }
        public Task<double> Handle(GetCurrency request, CancellationToken cancellationToken)
        {
            try
            {
                String URLString = _URLString + request.Data.source;
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    ExhchangeObject exhchangeObject = JsonConvert.DeserializeObject<ExhchangeObject>(json);
                    return Task.FromResult(GetCurrencyRate(request, exhchangeObject)); 
                }
            }
            catch (Exception)
            {
                return Task.FromResult((double)0);
            }
        }
        private double GetCurrencyRate(GetCurrency request, ExhchangeObject exhchangeObject)
        {
            return GetRateToSource(request.Data.destination, exhchangeObject.conversion_rates) * request.Data.amount;
        }   
        private double GetRateToSource(string rate, ConversionRate conversion_rates)
        {
            foreach (var currency in currencies)
            {
                if (currency == rate)
                {
                    return (double)GetPropValue(conversion_rates, currency);
                }
            }
            return 0;
        }
        public  object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }    
}
