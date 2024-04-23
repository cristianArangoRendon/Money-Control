using Microsoft.AspNetCore.Mvc;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;
using MoneyControl.Core.Interfaces.UserCases.User;

namespace MoneyControl.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUserCase _userUserCase;
        public UserController(IUserUserCase userUserCase) => _userUserCase = userUserCase;

        [HttpPost("/User")]
        public async Task<ResponseDTO>CheckIn(CheckInDTO checkIn) => await _userUserCase.CheckIn(checkIn);
    }
}
