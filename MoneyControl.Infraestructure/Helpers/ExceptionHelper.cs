using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Services;

namespace MoneyControl.Infraestructure.Helpers
{
    public class ExceptionHelper
    {
        public static ResponseDTO HandleException(ILogService logService, string methodName, Exception ex)
        {
            logService.SaveLogsMessages($"Se ha producido un error al ejecutar: {methodName}: {ex.Message}");
            var response = new ResponseDTO
            {
                Message = ex.ToString()
            };
            return response;
        }
    }
}
