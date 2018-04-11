using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.Logger
{
    class FileLogger : ILogger
    {
        private string _logPath;

        public string LogPath
        {
            get => _logPath;
            set => _logPath = value;
        }

        public void WriteLog(LogInfo logInfo)
        {
            if (logInfo == null)
            {
                throw new ArgumentNullException("logInfo");
            }

            string logDetailPath;
            if (logInfo.Type == LogType.Exception)
            {
                logDetailPath = _logPath + "\\Exception\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            else if (logInfo.Type == LogType.Operation)
            {
                logDetailPath = _logPath + "\\Operation\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            else
            {
                logDetailPath = _logPath + "\\Other\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }

            File.AppendAllText(logDetailPath, logInfo.Text, Encoding.UTF8);
        }
    }
}
