using MoneyControl.Core.DTOs.Incomin;
using MoneyControl.Core.DTOs.Response;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IInComeRepository
    {
        Task<ResponseDTO> CrateIncome(CreateIncomeDTO income);
        Task<ResponseDTO> GetIncomes(int iduser);
        Task<ResponseDTO> GetIncomeById(int id);
        Task<ResponseDTO> UpDateIncome(IncomeDTO income);
        Task<ResponseDTO> DeleteIncome(int id);
    }
}
