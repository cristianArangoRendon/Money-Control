using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Core.Interfaces.UserCases.Expense;
using MoneyControl.Core.Interfaces.UserCases.Frequency;
using MoneyControl.Core.Interfaces.UserCases.FutureGoal;
using MoneyControl.Core.Interfaces.UserCases.InCome;
using MoneyControl.Core.Interfaces.UserCases.User;
using MoneyControl.Infraestructure.UserCases.Expense;
using MoneyControl.Infraestructure.UserCases.Frequency;
using MoneyControl.Infraestructure.UserCases.FutureGoals;
using MoneyControl.Infraestructure.UserCases.Income;
using MoneyControl.Infraestructure.UserCases.User;

namespace MoneyControl.Infraestructure.UserCases.IOC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUserCase(this IServiceCollection services)
        {

            services.AddScoped<IUserUserCase, UserUserCase>();
            services.AddTransient<IFrequencyUseCase, FrequencyUseCase>();
            services.AddTransient<IFutureGoalUseCase, FutureGoalUseCase>();
            services.AddTransient<IIncomeUseCase, IncomeUseCase>();
            services.AddTransient<IExpenseUseCase, ExpenseUseCase>();
            
            

            return services;
        }
    }
}
