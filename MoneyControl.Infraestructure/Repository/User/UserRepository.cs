using Microsoft.Extensions.Configuration;
using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.DTOs.User;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using MoneyControl.Infraestructure.Helpers;
using MoneyControl.Infraestructure.Repository.DataContext;
using System.Data.SqlClient;
using System.Data;

namespace MoneyControl.Infraestructure.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IExecuteStoreProcedureService _executeStoreProcedureService;
        private readonly IDataContext _dataContext;
        public UserRepository(IConfiguration configuration, IExecuteStoreProcedureService executeProcedure, IDataContext context)
        {
            _executeStoreProcedureService = executeProcedure;
            _dataContext = context;
        }

        public async Task<ResponseDTO> CheckIn(CheckInDTO checkIn)
        {
            object obj = checkIn.ToObject<CheckInDTO>();
            return await _executeStoreProcedureService.ExecuteStoredProcedure("dbo.PutUser", obj);
        }

        public async  Task<ResponseDTO> LogIn(LoginDTO Login)
        {
            object obj = Login.ToObject<LoginDTO>();
            return await _executeStoreProcedureService.ExecuteStoredProcedure("dbo.GetUserLogin", obj);
        }

        public async Task<UserInfoDTO> GetUserByEmail(string email)
        {
            using SqlCommand command = _dataContext.CreateCommand();
            command.CommandText = "dbo.GetUserByEmail";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@email", email);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            UserInfoDTO userdto = MapToObjHelper.MapToObj<UserInfoDTO>(reader);
            return userdto;
           
        }
    }
}
