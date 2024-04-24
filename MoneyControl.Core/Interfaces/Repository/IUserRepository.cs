using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        public Task<ResponseDTO> CheckIn(CheckInDTO checkIn);
        public Task<ResponseDTO> LogIn(LoginDTO Login);
        public Task<UserInfoDTO> GetUserByEmail(string email);
    }
}
