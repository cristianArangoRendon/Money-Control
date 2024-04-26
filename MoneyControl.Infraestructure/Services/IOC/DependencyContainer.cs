using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Services.ExecuteStoreProcedure;
using MoneyControl.Infraestructure.Services.Logservice;
using MoneyControl.Infraestructure.Services.SqlCommandservice;

namespace MoneyControl.Infraestructure.Services.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IExecuteStoreProcedureService, ExecuteStoreProcedureService>();
            services.AddTransient<ISqlCommandService, SqlCommandService>();
            services.AddTransient<ILogService, LogService>();
            return services;
        }
    }
}
