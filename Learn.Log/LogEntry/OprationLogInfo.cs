using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.LogEntry
{
    public class ExceptionLogInfo : LogInfo
    {
        private string _exceptionMessage;
        private string _exceptionStackTrace;

        public string ExceptionMessage
        {
            get => _exceptionMessage;
            set => _exceptionMessage = value;
        }
        public string ExceptionStackTrace
        {
            get => _exceptionStackTrace;
            set => _exceptionStackTrace = value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendFormat("在{0}发生异常：{1}",this.CreateTime,this.ExceptionMessage);
            builder.AppendLine();
            builder.AppendFormat(this.ExceptionStackTrace);
            builder.AppendLine();
            builder.Append("------------------------------------------------------------");
            return builder.ToString();
        }
    }
}
