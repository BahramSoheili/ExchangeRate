using ExchangeRateApisManager.Domains.Currency.Handlers.QueryHandlers;
using ExchangeRateApisManager.Domains.Currency.Queries;
using ExchangeRateApisManager.Domains.Currency.View;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeRateApisManager
{
    public static class ConfigCurrency
    {
        public static void AddConfig(this IServiceCollection services)
        {
            services.AddConfigCurrencyScope();
        }

        private static void AddConfigCurrencyScope(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<GetCurrency, double>, CurrencyQueryHandler>();

        }
    }
}
