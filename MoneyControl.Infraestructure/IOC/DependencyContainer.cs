using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Infraestructure.Repository.IOC;
using MoneyControl.Infraestructure.Services.IOC;
using MoneyControl.Infraestructure.UserCases.IOC;

namespace MoneyControl.Infraestructure.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection

       AddProyectoFinal(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddUserCase();
            services.AddRepository();
            services.AddServices();
            return services;
        }
    }
}
