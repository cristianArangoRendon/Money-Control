using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Services.ExecuteStoreProcedure;

namespace MoneyControl.Infraestructure.Services.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IExecuteStoreProcedureService, ExecuteStoreProcedureService>();
            return services;
        }
    }
}
