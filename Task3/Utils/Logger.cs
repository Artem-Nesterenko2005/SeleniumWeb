using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Task3;

static public class Logger
{
    private const string pathToLogFile = "../../../log.txt";

    private static ILogger logger;

    public static void LogInfo(string text) => logger.LogInformation(text);

    static Logger()
    {
        Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File(pathToLogFile).CreateLogger();

        using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddSerilog(Log.Logger);
            builder.SetMinimumLevel(LogLevel.Debug);
        });
        logger = loggerFactory.CreateLogger("Logger");
    }
}
