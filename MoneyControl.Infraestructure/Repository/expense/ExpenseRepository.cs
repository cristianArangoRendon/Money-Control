using MoneyControl.Core.DTOs.Expense;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.Repository.expense
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly ILogService _logService;
        public ExpenseRepository(IExecuteStoreProcedureService executeStoreProcedureService,ILogService logService)
        {
            _executeStoreProcedureService = executeStoreProcedureService;
            _logService = logService;
        }
        public async Task<ResponseDTO> CreateExpense(CreateExpenseDTO expense)
        {
            try
            { object obj = expense.ToObject<CreateExpenseDTO>();
                return await _executeStoreProcedureService.ExecuteStoredProcedure("CreateExpenses", obj);
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
                object obj = new
                {
                    idUser = idUser,
                };
                return await _executeStoreProcedureService.ExecuteDataStoredProcedure("GetExpenses", obj, MapToListHelper.MapToList<GetExpenseDTO>);
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
                object obj = new
                {
                    id = id,
                };
                return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure("GetExpenseById", obj,MapToObjHelper.MapToObj<GetExpenseDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService,System.Reflection.MethodBase.GetCurrentMethod().Name,ex);
            }
        }

        public async Task<ResponseDTO> UpDateExpense(UpDateExpenseDTO expense)
        {
            try
            {
                object obj = expense.ToObject<UpDateExpenseDTO>();

                return await _executeStoreProcedureService.ExecuteStoredProcedure("UpdateExpenses",obj);
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
                object obj = new
                {
                    id = id,
                };
                return await _executeStoreProcedureService.ExecuteStoredProcedure("DeleteExpense", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
