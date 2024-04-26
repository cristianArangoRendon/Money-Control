using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.Core.DTOs.FutureGoal;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.UserCases.FutureGoal;

namespace MoneyControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureGoalController : ControllerBase
    {
        private readonly IFutureGoalUseCase _futureGoalUseCase;
        public FutureGoalController(IFutureGoalUseCase futureGoalUseCase) => _futureGoalUseCase = futureGoalUseCase;

        [HttpGet("/GetFutureGoals")]
        public async Task<ResponseDTO> GetFutureGoals(int idUser)=> await _futureGoalUseCase.GetFutureGoals(idUser);
        [HttpGet("/GetFutureGoalById")]
        public async Task<ResponseDTO> GetFutureGoalById(int id) => await _futureGoalUseCase.GetFutureGoalById(id);
        [HttpPost("/CreateFutureGoal")]
        public async Task<ResponseDTO> CreateFutureGoal(CreateFutureGoalDTO futureGoal) => await _futureGoalUseCase.CreateFutureGoal(futureGoal);
        [HttpPut("/UpdateFutureGoal")]
        public async Task<ResponseDTO> UpdateFutureGoal(FutureGoalDTO futureGoal) => await _futureGoalUseCase.UpdateFutureGoal(futureGoal);
        [HttpDelete("/DeleteFutureGoal")]
        public async Task<ResponseDTO> DeleteFutureGoal(int id)=> await _futureGoalUseCase.DeleteFutureGoal(id);

    }
}
