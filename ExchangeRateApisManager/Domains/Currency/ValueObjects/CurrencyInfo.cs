namespace ExchangeRateApisManager.Domains.Currency.ValueObjects
{
    public class CurrencyInfo
    {
        public string source { get; set; }
        public string destination { get; set; }
        public double amount { get; set; }
    }
}
