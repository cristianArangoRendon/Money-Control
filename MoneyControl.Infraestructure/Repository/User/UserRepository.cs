using Microsoft.Extensions.Configuration;
using MoneyControl.Core.DTOs;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;

namespace MoneyControl.Infraestructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogService _logService;
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly AuthSettings _authSettings;

        public UserRepository(IConfiguration configuration, ILogService logService, IExecuteStoreProcedureService executeProcedure)
        {
            _logService = logService;
            _executeStoreProcedureService = executeProcedure;
        }
        public async Task<ResponseDTO> CheckIn(CheckInDTO checkIn)
        {
            object obj = checkIn.ToObject<CheckInDTO>();
            return await _executeStoreProcedureService.ExecuteStoredProcedure("dbo.PutUser", obj);
        }
    }
}
