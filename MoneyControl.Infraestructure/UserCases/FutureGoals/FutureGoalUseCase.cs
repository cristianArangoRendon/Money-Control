using MoneyControl.Core.DTOs.FutureGoal;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.FutureGoal;
using MoneyControl.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.UserCases.FutureGoals
{
    public class FutureGoalUseCase : IFutureGoalUseCase
    {
        private readonly IFutureGoalRepository _futureGoalRepository;
        private readonly ILogService _logService;
        public FutureGoalUseCase(IFutureGoalRepository futureGoalRepository,ILogService logService)
        {
                _futureGoalRepository = futureGoalRepository;   
                _logService = logService;
        }
        public async Task<ResponseDTO> CreateFutureGoal(CreateFutureGoalDTO futureGoal)
        {
            try
            {
                if (futureGoal.approximateValue>0)
                {
                    return await _futureGoalRepository.CreateFutureGoal(futureGoal);
                }
                else
                {
                    ResponseDTO response = new ResponseDTO();
                    response.Message = "the amount must be greater than 0";
                    return response;
                }
            }
            catch (Exception ex )
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async  Task<ResponseDTO> DeleteFutureGoal(int id)
        {
            try
            {
                return await _futureGoalRepository.DeleteFutureGoal(id);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        public async  Task<ResponseDTO> GetFutureGoalById(int id)
        {
            try
            {
                return await _futureGoalRepository.GetFutureGoalById(id);
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
                return await _futureGoalRepository.GetFutureGoals(idUser);
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
               
                if (futureGoal.approximateValue > 0)
                {
                    return await _futureGoalRepository.UpdateFutureGoal(futureGoal);
                }
                else
                {
                    ResponseDTO response = new ResponseDTO();
                    response.Message = "the amount must be greater than 0";
                    return response;
                }
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
