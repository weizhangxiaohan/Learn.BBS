using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Learn.Log.LogEntry;

namespace Learn.Log.Logger
{
    class FileLogger : ILogger
    {
        private string _logRootPath;
        private bool _enableQueue;
        private Queue<LogInfo> _cacheQueue;

        internal FileLogger (string logRootPath,bool enableQueue)
        {
            _logRootPath = logRootPath;
            _enableQueue = enableQueue;

            if (_enableQueue)
            {
                _cacheQueue = new Queue<LogInfo>();

                Task.Run(() =>
                {
                    try
                    {
                        while (true)
                        {
                            StringBuilder builder = new StringBuilder();
                            for (int i = 0; i < 100; i++)
                            {
                                if (_cacheQueue.Count > 0)
                                {
                                    LogInfo logInfo = _cacheQueue.Dequeue();
                                    builder.Append(logInfo.Text);
                                    builder.AppendLine();
                                    builder.Append("---------------------------------------------------------");
                                }
                            }

                            File.AppendAllText("", builder.ToString(), Encoding.UTF8);

                            builder.Clear();

                            Thread.Sleep(3000);
                        }
                    }
                    catch (Exception ex)
                    {
                        string text = "\r\n" + "发生异常，后台日志线程已退出：" + "\r\n" + ex.ToString() + "\r\n";
                        File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\ThreadLog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", text, System.Text.Encoding.UTF8);
                    }

                });
            }
        }

        public string LogRootPath
        {
            get => _logRootPath;
            set => _logRootPath = value;
        }

        public void WriteLog(LogInfo logInfo)
        {
            if (logInfo == null)
            {
                throw new ArgumentNullException("logInfo");
            }

            if (_enableQueue)
            {
                _cacheQueue.Enqueue(logInfo);
            }
            else
            {
                string logDetailPath = GetDetailPath(logInfo);
                File.AppendAllText(logDetailPath, logInfo.ToString(), Encoding.UTF8);
            }

        }

        /// <summary>
        /// 按日志类型得到存储的具体物理路径
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <returns>具体路径</returns>
        private string GetDetailPath(LogInfo logInfo)
        {
            string logDetailPath;
            if (logInfo is ExceptionLogInfo)
            {
                logDetailPath = _logRootPath + "\\Exception\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            else if (logInfo is OperationLogInfo)
            {
                logDetailPath = _logRootPath + "\\Operation\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            else
            {
                logDetailPath = _logRootPath + "\\General\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            }
            return logDetailPath;
        }

        private void WriteToFile(List<LogInfo> logs)
        {

        }
    }
}
