using MoneyControl.Core.DTOs.Expense;
using MoneyControl.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.Interfaces.UserCases.Expense
{
    public interface IExpenseUseCase
    {
        Task<ResponseDTO> CreateExpense(CreateExpenseDTO expense);
        Task<ResponseDTO> UpDateExpense(UpDateExpenseDTO expense);
        Task<ResponseDTO> GetExpenses(int idUser);
        Task<ResponseDTO> GetExpensesById(int id);
        Task<ResponseDTO> DelteExpense(int id);
    }
}
