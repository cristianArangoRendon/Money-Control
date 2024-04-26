using MoneyControl.Core.DTOs.Expense;
using MoneyControl.Core.DTOs.FutureGoal;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.Repository.FutureGoal
{
    public class FutureGoalRepository : IFutureGoalRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly ILogService _logService;
        public FutureGoalRepository(IExecuteStoreProcedureService executestroreprocedureservice,ILogService logService)
        {
                _executeStoreProcedureService = executestroreprocedureservice;
            _logService = logService;   
        }
        public async Task<ResponseDTO> CreateFutureGoal(CreateFutureGoalDTO futureGoal)
        {
            try
            {
                object obj = futureGoal.ToObject<CreateFutureGoalDTO>();
                return await _executeStoreProcedureService.ExecuteStoredProcedure("CreateFutureGoal", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async  Task<ResponseDTO> DeleteFutureGoal(int id)
        {
            try
            {
                object obj = new
                {
                    id = id,
                };
                return await _executeStoreProcedureService.ExecuteStoredProcedure("DeleteFutureGoal", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetFutureGoalById(int id)
        {
            try
            {
                object obj = new
                {
                    id = id,
                };
                return await _executeStoreProcedureService.ExecuteSingleObjectStoredProcedure("GetFutureGoalById", obj, MapToObjHelper.MapToObj<FutureGoalDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async Task<ResponseDTO> GetFutureGoals(int idUser)
        {
            try
            {
                object obj = new
                {
                    idUser = idUser,
                };
                return await _executeStoreProcedureService.ExecuteDataStoredProcedure("GetFutureGoals", obj, MapToListHelper.MapToList<FutureGoalDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }

        }

        public async Task<ResponseDTO> UpdateFutureGoal(FutureGoalDTO futureGoal)
        {
            try
            {
                object obj = futureGoal.ToObject<FutureGoalDTO>();

                return await _executeStoreProcedureService.ExecuteStoredProcedure("UpdateFutureGoal", obj);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
