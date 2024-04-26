using MoneyControl.Core.DTOs.Frequency;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Infraestructure.Repository.Frequency
{
    internal class FrequencyRepository : IFrequencyRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly ILogService _logService;
        public FrequencyRepository(IExecuteStoreProcedureService executeStoreProcedureService, ILogService logService)
        {
                _executeStoreProcedureService = executeStoreProcedureService;
            _logService = logService;
        }
        public async Task<ResponseDTO> GetFrequencys()
        {
            try
            {
                return await _executeStoreProcedureService.ExecuteDataStoredProcedure("GetFrequencys",null,MapToListHelper.MapToList<FrequencyDTO>);
            }
            catch (Exception ex)
            {

                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
