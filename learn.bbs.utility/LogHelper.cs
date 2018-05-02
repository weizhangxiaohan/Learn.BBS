using Learn.Log;
using Learn.Log.LogEntry;
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


        public static void LogToFile(string message)
        {
            GeneralLogInfo logInfo = new GeneralLogInfo();
            logInfo.Message = message;
            logInfo.CreateTime = DateTime.Now;
            LogToFile(logInfo);
        }

        public static void LogToFile(Exception ex)
        {
            ExceptionLogInfo logInfo = new ExceptionLogInfo();
            logInfo.ExceptionMessage = ex.Message;
            logInfo.ExceptionStackTrace = ex.StackTrace;
            logInfo.CreateTime = DateTime.Now;
            LogToFile(logInfo);
        }


        public static void LogToFile(LogInfo logInfo)
        {
            FileLogger.WriteLog(logInfo);
        }

    }
}
