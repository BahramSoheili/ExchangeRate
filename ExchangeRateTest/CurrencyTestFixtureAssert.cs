using Core.Testing;
using ExchangeRateApis;
using ExchangeRateApisManager.Domains.Currency.Queries;
using ExchangeRateApisManager.Domains.Currency.ValueObjects;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace ExchangeRateTest
{
    public class CurrencyTestFixtureAssert: ApiFixture<Startup>
    {
        public const string ExchangeRateApis = "ExchangeRateApis";
        public override string ApiUrl { get; } = QueryUrls.CurrencyUrl;
        double actual;
        
        public readonly CurrencyInfo Data = new CurrencyInfo()
        {
            sourceCurrency = "GBP",
            destinationCurrency = "EUR",
            value = 20
        };
        public HttpResponseMessage CommandResponse;
        public override async Task InitializeAsync()
        {
            CommandResponse = await Client.PostAsync(ApiUrl, Data.ToJsonStringContent());
            var result = await CommandResponse.Content.ReadAsStringAsync();
            actual = Math.Round(double.Parse(result), 2, MidpointRounding.AwayFromZero);
        }
        [Theory]
        [InlineData(23)]
        public void ExchangeRateTest(double expected)
        {
            try
            {
                Assert.InRange(actual, expected-1, expected +1);
            }
            catch
            {
                throw ;
            }
        }

    }
}
