
using Microsoft.Extensions.Logging;

namespace CakeCompany.Logging
{
    /// <summary>
    /// LoggingProvider - Class to provide Logging functionalities
    /// </summary>
    public class LoggingProvider
    {
        /// <summary>
        /// SetLogger - Sets the Logger Factory to enable logging for the needed classes and methods
        /// </summary>
        /// <returns></returns>
        public static ILoggerFactory SetLogger()
        {
            return LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
        }
    }
}
