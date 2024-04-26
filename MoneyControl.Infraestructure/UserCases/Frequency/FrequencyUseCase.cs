using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.Frequency;
using MoneyControl.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.UserCases.Frequency
{
    public class FrequencyUseCase : IFrequencyUseCase
    {
        private readonly IFrequencyRepository _frequencyRepository;
        private readonly ILogService _logService;
        public FrequencyUseCase(IFrequencyRepository frequencyRepository, ILogService logService)
        {
                _frequencyRepository = frequencyRepository;
            _logService = logService;
        }
        public async Task<ResponseDTO> GetFrequencys()
        {
            try
            {
                return await _frequencyRepository.GetFrequencys();
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
