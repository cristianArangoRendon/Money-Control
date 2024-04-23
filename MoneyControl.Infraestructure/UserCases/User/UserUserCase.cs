using Microsoft.Extensions.Configuration;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.User;
using MoneyControl.Infraestructure.Helpers.Hash;

namespace MoneyControl.Infraestructure.UserCases.User
{
    public class UserUserCase : IUserUserCase
    {
        private readonly ILogService _logService;
        private readonly IUserRepository _userRepository;
        public UserUserCase( ILogService logService, IUserRepository user, IConfiguration configuration)
        {
            _logService = logService;
            _userRepository = user;
        }
        public async Task<ResponseDTO> CheckIn(CheckInDTO checkIn)
        {
            ResponseDTO response = new ResponseDTO();
            try 
            {
                if(checkIn.age >= 18)
                {
                    checkIn.password = Hash256.GetSHA256Hash(checkIn.password);
                    return await _userRepository.CheckIn(checkIn);
                }
                response.Message = "Debes tener más de 18 años.";
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
