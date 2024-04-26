using MoneyControl.Core.DTOs.Response;
using MoneyControl.Core.Interfaces.Repository;
using MoneyControl.Core.Interfaces.Services;
using System.Data;
using System.Data.SqlClient;

namespace MoneyControl.Infraestructure.Services.ExecuteStoreProcedure
{
    public class ExecuteStoreProcedureService : IExecuteStoreProcedureService
    {

        private readonly IDataContext _DataContext;
        private readonly ILogService _logService;
        private readonly ISqlCommandService _sqlCommandService;
        public ExecuteStoreProcedureService(IDataContext datacontext, ILogService logs, ISqlCommandService command)
        {
            _DataContext = datacontext;
            _logService = logs;
            _sqlCommandService = command;
        }

        public async Task<ResponseDTO> ExecuteData<TResult>(string storedProcedureName, Func<SqlDataReader, List<TResult>> mapFunction)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using SqlCommand command = _DataContext.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                List<TResult> resultList = mapFunction(reader);
                response.IsSuccess = true;
                response.Message = reader.GetString(reader.GetOrdinal("ResultMessage"));
                response.Data = resultList;
                return response;
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessages($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
                return response;
            }

        }

        public async Task<ResponseDTO> ExecuteDataStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<SqlDataReader, List<TResult>> mapFunction)
        {
            ResponseDTO response = new ResponseDTO();
            response.IsSuccess = false;
            try
            {
                using SqlCommand command = _DataContext.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                List<TResult> resultList = mapFunction(reader);
                response.IsSuccess = true;
                response.Message = "Exito";
                response.Data = resultList;
                return response;
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessages($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
                return response;
            }
        }



        public async Task<ResponseDTO> ExecuteSingleObjectStoredProcedure<TResult>(string storedProcedureName, object parameters, Func<SqlDataReader, TResult> mapFunction)
        {
            ResponseDTO response = new ResponseDTO();
            
            try
            {
                using SqlCommand command = _DataContext.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                TResult resultList = mapFunction(reader);
                response.IsSuccess = true;
                response.Message = "Exito";
                response.Data = resultList;
                return response;
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessages($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
                return response;
            }

        }


        public async Task<ResponseDTO> ExecuteStoredProcedure(string storedProcedureName, object parameters)
        {
            ResponseDTO response = new ResponseDTO();
            

            try
            {
                using SqlCommand command = _DataContext.CreateCommand();
                command.CommandText = storedProcedureName;
                command.CommandType = CommandType.StoredProcedure;
                _sqlCommandService.AddParameters(command, parameters);
                using SqlDataReader reader = await command.ExecuteReaderAsync();
                await reader.ReadAsync();
                response.Message = reader.GetString(reader.GetOrdinal("ResultMessage"));
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                _logService.SaveLogsMessages($"Se ha producido un error al ejecutar el SP {storedProcedureName}: {ex.Message}");
                response.Message += ex.ToString();
                return response;
            }

        }

    }
}
