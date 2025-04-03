using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;

namespace Authentification.JWT.Service.Logging
{
    public class LoggerService : ILoggerService
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarning(string message)
        {
            logger.Warn(message);
        }

        public void LogError(string message, Exception ex = null)
        {
            logger.Error(ex, message);
        }
    }
}
