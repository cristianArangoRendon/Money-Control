using System.Data.SqlClient;

namespace MoneyControl.Core.Interfaces.Repository
{
    public interface IDataContext
    {
        SqlConnection GetConnection();
        SqlCommand CreateCommand();
    }
}
