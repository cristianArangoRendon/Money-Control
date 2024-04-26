using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.Core.DTOs.Incomin;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.UserCases.InCome;

namespace MoneyControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeUseCase _incomeUseCase;
        public  IncomeController(IIncomeUseCase incomeUseCase) => _incomeUseCase = incomeUseCase;

        [HttpGet("/GetIncomes")]
        public async Task<ResponseDTO> GetIncomes(int idUser) => await _incomeUseCase.GetIncomes(idUser);

        [HttpGet("/GetIncomesById")]
        public async Task<ResponseDTO> GetInComesById(int id) => await _incomeUseCase.GetIncomeById(id);

        [HttpPost("/CreateIncome")]
        public async Task<ResponseDTO> CreateIncome(CreateIncomeDTO income) => await _incomeUseCase.CrateIncome(income);
        [HttpPut("/UpdateIncome")]
        public async Task<ResponseDTO> UpdateIncome(IncomeDTO income)=>  await _incomeUseCase.UpDateIncome(income);
        [HttpDelete("/DeleteIncome")]
        public async Task<ResponseDTO> DeleteIncome(int id) => await _incomeUseCase.DeleteIncome(id);
    }
}
