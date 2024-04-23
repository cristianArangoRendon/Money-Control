using MoneyControl.Core.DTOs.Response;
using System.Data.SqlClient;

namespace MoneyControl.Core.Interfaces.Services
{
    public interface IExecuteStoreProcedureService
    {
        Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters);
        Task<ResponseDTO> ExecuteDataStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<SqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteData<TResult>(string storedProcedureName, Func<SqlDataReader, List<TResult>> mapFunction);
        Task<ResponseDTO> ExecuteSingleObjectStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<SqlDataReader, TResult> mapFunction);
    }
}
