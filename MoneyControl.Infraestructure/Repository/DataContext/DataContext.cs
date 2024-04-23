using Microsoft.Extensions.Configuration;
using MoneyControl.Core.Interfaces.Repository;
using System.Data;
using System.Data.SqlClient;

namespace MoneyControl.Infraestructure.Repository.DataContext
{
    public class DataContext : IDisposable, IDataContext
    {
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            string cadenadb = _configuration.GetConnectionString("DefaultConnection") ?? "";

            if (connection == null)
            {
                connection = new SqlConnection(cadenadb);
                connection.Open();
            }
            else if (connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(cadenadb);
                connection.Open();
            }

            return connection;
        }

        public SqlCommand CreateCommand()
        {
            var command = new SqlCommand();
            command.Connection = GetConnection();
            command.CommandType = CommandType.Text;
            return command;
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
