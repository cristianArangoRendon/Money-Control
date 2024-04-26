using MoneyControl.Core.DTOs.Expense;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.Expense;
using MoneyControl.Infraestructure.Helpers;

namespace MoneyControl.Infraestructure.UserCases.Expense
{
    public class ExpenseUseCase : IExpenseUseCase
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ILogService _logService;
        public ExpenseUseCase(IExpenseRepository expenseRepository,ILogService logService)
        {
            _expenseRepository = expenseRepository;
            _logService = logService;
        }
        public async Task<ResponseDTO> CreateExpense(CreateExpenseDTO expense)
        {
            try
            {
                if (expense.amount > 0)
                {
                    return await  _expenseRepository.CreateExpense(expense);
                }
                else
                { ResponseDTO response = new ResponseDTO();
                    response.Message = "the amount must be greater than 0";
                    return response;
                }


            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetExpenses(int idUser)
        {
            try
            {
                return await _expenseRepository.GetExpenses(idUser);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetExpensesById(int id)
        {
            try
            {
                return await _expenseRepository.GetExpensesById(id);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> UpDateExpense(UpDateExpenseDTO expense)
        {
            try
            {
                if(expense.amount > 0)
                {
                    return await _expenseRepository.UpDateExpense(expense);
                }
                else
                { ResponseDTO response = new ResponseDTO();
                    response.Message = "the amount must be greater than 0";
                    return response;
                }
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService,System.Reflection.MethodBase.GetCurrentMethod().Name,ex);
            }
        }
        public async Task<ResponseDTO> DelteExpense(int id)
        {
            try
            {
                return await  _expenseRepository.DelteExpense(id);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
