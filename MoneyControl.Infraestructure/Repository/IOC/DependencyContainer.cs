using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Infraestructure.Repository.User;

namespace MoneyControl.Infraestructure.Repository.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
