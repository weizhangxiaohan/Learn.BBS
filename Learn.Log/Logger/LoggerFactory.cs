using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.Logger
{
    public class LoggerFactory
    {
        public static ILogger CreateFileLogger(string logRootPath)
        {
            FileLogger logger =  new FileLogger(logRootPath,true);
            return logger;
        }
    }
}
