using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyControl.Core.DTOs.Expense;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.UserCases.Expense;

namespace MoneyControl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseUseCase _expenseUseCase;
        public ExpenseController(IExpenseUseCase expenseUseCase)=> _expenseUseCase  = expenseUseCase;


        [HttpGet("/GetExpenses")]
        public async Task<ResponseDTO> GetExpenses(int idUser) => await _expenseUseCase.GetExpenses(idUser);
        [HttpGet("/GetExpenseById")]
        public async Task<ResponseDTO> GetExpenseById(int id) => await _expenseUseCase.GetExpensesById(id);
        [HttpPost("/CreateExpense")]
        public async Task<ResponseDTO> CreateExpense(CreateExpenseDTO expense)=> await _expenseUseCase.CreateExpense(expense);
        [HttpPut("/UpdateExpense")]
        public async Task<ResponseDTO> UpdateExpense(UpDateExpenseDTO expense) => await _expenseUseCase.UpDateExpense(expense);
        [HttpDelete("/DeleteExpense")]
        public async Task<ResponseDTO> DeleteExpense(int id) => await _expenseUseCase.DelteExpense(id);

        
    }
}
