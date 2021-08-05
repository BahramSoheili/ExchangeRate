namespace ExchangeRateApisManager.Domains.Currency.ValueObjects
{
    public class CurrencyInfo
    {
        public string sourceCurrency { get; set; }
        public string destinationCurrency { get; set; }
        public double value { get; set; }
    }
}
