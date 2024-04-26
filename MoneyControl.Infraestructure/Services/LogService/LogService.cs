using Microsoft.Extensions.Configuration;
using MoneyControl.Core.Interfaces.Services;

namespace MoneyControl.Infraestructure.Services.Logservice
{
    public class LogService : ILogService
    {
        private readonly IConfiguration _configuration;

        public LogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SaveLogsMessages(string messages)
        {
            var filePath = _configuration["PathLogs"];
            var directoryPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}] - *_* {messages}");
            }
        }
    }
}
