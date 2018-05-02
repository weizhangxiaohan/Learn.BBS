using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.LogEntry
{
    public class GeneralLogInfo : LogInfo
    {
        public string Message { get; set; }

        public override string Text
        {
            get
            {
                return Message + base.Text;
            }
        }

        public override LogType Type
        {
            get
            {
                return LogType.General;
            }
        }

        public override string GetDirectoryName()
        {
            return "General";
        }
    }
}
