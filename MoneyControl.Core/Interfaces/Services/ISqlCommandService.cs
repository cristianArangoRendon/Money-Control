using System.Data.SqlClient;

namespace MoneyControl.Core.Interfaces.Services
{
    public interface ISqlCommandService
    {
        void AddParameters<T>(SqlCommand command, T parameters);
    }
}
