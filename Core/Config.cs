using Core.Configuration;
using Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class Config
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR();
            services.AddScoped<IQueryBus, QueryBus>();
        }
    }
}
