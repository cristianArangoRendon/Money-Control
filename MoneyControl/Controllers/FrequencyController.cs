using Microsoft.AspNetCore.Mvc;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.UserCases.Frequency;

namespace MoneyControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrequencyController:ControllerBase
    {
        private readonly IFrequencyUseCase _frequencyUseCase;
        public FrequencyController(IFrequencyUseCase frequencyUseCase) => _frequencyUseCase = frequencyUseCase;
        [HttpGet("/GetFrequencys")]
        public async Task<ResponseDTO> GetFrequencys() => await _frequencyUseCase.GetFrequencys();
       
    }
}
