using TransferMarket.Data;
using Microsoft.Extensions.DependencyInjection;

namespace TransferMarket.API.DependencyRegistration
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<TransferMarketContext, TransferMarketContext>();
        }
    }
}
