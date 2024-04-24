using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.User;
using MoneyControl.Infraestructure.Repository.User;
using MoneyControl.Infraestructure.Services.LogService;
using MoneyControl.Infraestructure.Services.SqlCommandService;
using MoneyControl.Infraestructure.UserCases.User;

namespace MoneyControl.Infraestructure.UserCases.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUserCase(this IServiceCollection services)
        {

            services.AddScoped<IUserUserCase, UserUserCase>();
            services.AddTransient<ISqlCommandService, SqlCommandService>();
            services.AddTransient<ILogService, LogService>();

            return services;
        }
    }
}
