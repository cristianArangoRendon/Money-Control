using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;

namespace MoneyControl.Core.Interfaces.UserCases.User
{
    public interface IUserUserCase
    {
        public Task<ResponseDTO> CheckIn(CheckInDTO checkIn);
    }
}
