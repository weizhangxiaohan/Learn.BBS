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

        internal FileLogger(string logRootPath, bool enableQueue)
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
                            var dictionary = new Dictionary<string, StringBuilder>();

                            for (int i = 0; i < 100; i++)
                            {
                                if (_cacheQueue.Count > 0)
                                {
                                    LogInfo logInfo = _cacheQueue.Dequeue();
                                    string store_path = GetDetailPath(logInfo);
                                    if (!dictionary.ContainsKey(store_path))
                                    {
                                        dictionary.Add(store_path, new StringBuilder());
                                    }
                                    StringBuilder builder = dictionary[store_path];
                                    builder.Append(logInfo.Text);
                                    builder.AppendLine();
                                    builder.Append("---------------------------------------------------------");
                                }
                            }

                            foreach (var item in dictionary)
                            {
                                File.AppendAllText(item.Key, item.Value.ToString(), Encoding.UTF8);
                            }

                            Thread.Sleep(5000);
                        }
                    }
                    catch (Exception ex)
                    {
                        string text = "\r\n" + "发生异常，后台日志线程已退出：" + "\r\n" + ex.ToString() + "\r\n";
                        File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\ThreadLog\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", text, Encoding.UTF8);
                    }

                });
            }
        }

        public string LogRootPath
        {
            get { return _logRootPath; }
            set { _logRootPath = value; }
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
        /// 按得到日志存储具体物理路径
        /// </summary>
        /// <param name="logInfo">日志</param>
        /// <returns>具体路径</returns>
        private string GetDetailPath(LogInfo logInfo)
        {
            string logDetailPath = _logRootPath + "\\" + logInfo.GetDirectoryName() + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            return logDetailPath;
        }

        private void WriteToFile(List<LogInfo> logs)
        {

        }
    }
}
