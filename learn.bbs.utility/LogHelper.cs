using Learn.Log;
using Learn.Log.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.utility
{
    public class LogHelper
    {
        /* config start */
        private static string LogFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\Log";
        /* config end */

        private static ILogger _fileLogger;

        private static ILogger FileLogger
        {
            get
            {
                if (_fileLogger == null)
                {
                    _fileLogger = LoggerFactory.CreateFileLogger(LogFilePath);
                }
                return _fileLogger;
            }
        }

        public static void LogToFile(LogInfo logInfo)
        {
            FileLogger.WriteLog(logInfo);
        }

        public static void LogToFile(string text, LogType type)
        {
            LogInfo logInfo = new LogInfo();
            logInfo.Text = text;
            logInfo.Type = type;
            LogToFile(logInfo);
        }
    }
}
