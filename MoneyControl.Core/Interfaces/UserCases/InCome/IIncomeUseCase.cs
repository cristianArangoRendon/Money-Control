using MoneyControl.Core.DTOs.Incomin;
using MoneyControl.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.Interfaces.UserCases.InCome
{
    public interface IIncomeUseCase
    {
        Task<ResponseDTO> CrateIncome(CreateIncomeDTO income);
        Task<ResponseDTO> GetIncomes(int iduser);
        Task<ResponseDTO> GetIncomeById(int id);
        Task<ResponseDTO> UpDateIncome(IncomeDTO income);
        Task<ResponseDTO> DeleteIncome(int id);
    }
}
