using MoneyControl.Core.DTOs.Incomin;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;

namespace MoneyControl.Infraestructure.Repository.Income
{
    public class IncomeRepository : IInComeRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly ILogService _logService;   
        public IncomeRepository(IExecuteStoreProcedureService executeStoreProcedureService,ILogService logService)
        {
            _executeStoreProcedureService = executeStoreProcedureService;
            _logService = logService;
        }
        public async Task<ResponseDTO> CrateIncome(CreateIncomeDTO income)
        {
            try
            {
                object obj = income.ToObject<CreateIncomeDTO>();
                return await _executeStoreProcedureService.ExecuteStoredProcedure("CreateIncome", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> DeleteIncome(int id)
        {
            try
            {
                object obj = new
                {
                    id = id
                };
                return await _executeStoreProcedureService.ExecuteStoredProcedure("DeleteIncome", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> GetIncomeById(int  id)
        {
            try
            {
                object obj = new
                {
                    id = id
                };
                return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure("GetIncomesById", obj,MapToObjHelper.MapToObj<IncomeByIdDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> GetIncomes(int idUser)
        {
            try
            {
                object obj = new
                {
                    idUser = idUser
                };
                return await _executeStoreProcedureService.ExecuteDataStoredProcedure("GetIncomes", obj, MapToListHelper.MapToList<IncomeByIdDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> UpDateIncome(IncomeDTO income)
        {
            try
            {
                object obj = income.ToObject<IncomeDTO>();
                return await _executeStoreProcedureService.ExecuteStoredProcedure("UpDateIncome", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }
    }
}
