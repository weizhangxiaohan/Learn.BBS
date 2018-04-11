using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.Logger
{
    public interface ILogger
    {
        void WriteLog(LogInfo logInfo);
    }
}
