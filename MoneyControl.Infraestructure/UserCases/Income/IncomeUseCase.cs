using MoneyControl.Core.DTOs.Incomin;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.InCome;
using MoneyControl.Infraestructure.Helpers;

namespace MoneyControl.Infraestructure.UserCases.Income
{
    public class IncomeUseCase : IIncomeUseCase
    {
        private readonly IInComeRepository _IncomeRepository;
        private readonly ILogService _logService;
        public IncomeUseCase(IInComeRepository IncomeRepository , ILogService LogService)
        {
            _IncomeRepository = IncomeRepository;
            _logService = LogService;
        }
        
        
        public async Task<ResponseDTO> CrateIncome(CreateIncomeDTO income)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                if (income.amount > 0)
                {
                    return await _IncomeRepository.CrateIncome(income);
                }
                else
                {
                    response.Message = "the amount must be greater than 0";
                    return response;
                }
            }
            catch (Exception ex )
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> DeleteIncome(int id)
        {
            try
            {
                return await _IncomeRepository.DeleteIncome(id);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async  Task<ResponseDTO> GetIncomeById(int id)
        {
            try
            {
                return await _IncomeRepository.GetIncomeById(id);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> GetIncomes(int iduser)
        {
            try
            {
                return await _IncomeRepository.GetIncomes(iduser);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);

            }
        }

        public async Task<ResponseDTO> UpDateIncome(IncomeDTO income)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {
                if (income.amount > 0)
                {
                    return await _IncomeRepository.UpDateIncome(income);
                }
                else
                {
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
