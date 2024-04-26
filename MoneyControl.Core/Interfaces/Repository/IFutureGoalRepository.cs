using MoneyControl.Core.DTOs.FutureGoal;
using MoneyControl.Core.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IFutureGoalRepository
    {
        Task<ResponseDTO> CreateFutureGoal(CreateFutureGoalDTO futureGoal);
        Task<ResponseDTO> UpdateFutureGoal(FutureGoalDTO futureGoal);
        Task<ResponseDTO> GetFutureGoals(int idUser);
        Task<ResponseDTO> GetFutureGoalById(int id);
        Task<ResponseDTO> DeleteFutureGoal(int id);
    }
}
