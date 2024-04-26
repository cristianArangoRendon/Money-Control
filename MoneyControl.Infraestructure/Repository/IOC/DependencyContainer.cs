using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Infraestructure.Repository.expense;
using MoneyControl.Infraestructure.Repository.Frequency;
using MoneyControl.Infraestructure.Repository.FutureGoal;
using MoneyControl.Infraestructure.Repository.Income;
using MoneyControl.Infraestructure.Repository.User;
using MoneyControl.Infraestructure.Repository.Datacontext;

namespace MoneyControl.Infraestructure.Repository.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IDataContext,DataContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFrequencyRepository, FrequencyRepository>();
            services.AddTransient<IFutureGoalRepository, FutureGoalRepository>();
            services.AddTransient<IInComeRepository, IncomeRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            return services;
        }
    }
}
