using Microsoft.Extensions.Configuration;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Core.Interfaces.UserCases.User;
using MoneyControl.Infraestructure.Helpers;
using MoneyControl.Infraestructure.Helpers.Hash;

namespace MoneyControl.Infraestructure.UserCases.User
{
    public class UserUserCase : IUserUserCase
    {
        private readonly ILogService _logService;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserUserCase( ILogService logService, IUserRepository user, IConfiguration configuration)
        {
            _logService = logService;
            _userRepository = user;
            _configuration = configuration;
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
                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            
        }

        public async  Task<ResponseDTO> LogIn(LoginDTO Login)
        {
            ResponseDTO response = new ResponseDTO();
            try
            {

                    Login.password = Hash256.GetSHA256Hash(Login.password);

                    var result = await _userRepository.LogIn(Login);
                    if(result.Message == "OK")
                    {
                         UserInfoDTO userForClaims =  await _userRepository.GetUserByEmail(Login.email);
                        string Key = _configuration["JWT:Key"];
                        int Hours = int.Parse(_configuration["JWT:Hours"]);
                        result.Data = GenerateTokenHelper.GenerateToken(userForClaims,Key, Hours );
                        
                    }
                return result;
                
                
              
            }
            catch (Exception ex)
            {
                return ExceptionHelper.HandleException(_logService, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
            }
            throw new NotImplementedException();
        }


    }
}
