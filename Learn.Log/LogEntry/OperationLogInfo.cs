using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.LogEntry
{
    public class OperationLogInfo : LogInfo
    {
        private string _targetUrl;

        public override LogType Type
        {
            get
            {
                return LogType.Exception;
            }
        }

        public override string Text
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine();
                builder.AppendFormat("在{0}：{1}访问了{2}",CreateTime,Creator,TargetUrl);
                return builder.ToString();
            }
        }

        public string TargetUrl
        {
            get => _targetUrl;
            set => _targetUrl = value;
        }

        public override string GetDirectoryName()
        {
            return "Operation";
        }
    }
}
