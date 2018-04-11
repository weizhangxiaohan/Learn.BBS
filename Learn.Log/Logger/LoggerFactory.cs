using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.Logger
{
    public class LoggerFactory
    {
        public static ILogger CreateFileLogger(string logFilePath)
        {
            FileLogger logger =  new FileLogger();
            logger.LogPath = logFilePath;
            return logger;
        }
    }
}
