﻿using System;
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
            get
            {
                return _exceptionMessage;
            }
            set
            {
                _exceptionMessage = value;
            }
        }
        public string ExceptionStackTrace
        {
            get
            {
                return _exceptionStackTrace;
            }
            set
            {
                _exceptionStackTrace = value;
            }
        }

        public override LogType Type
        {
            get
            {
                return LogType.Exception;
            }
        }

        public override string GetDirectoryName()
        {
            return "Exception";
        }

        public override string Text
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine();
                builder.AppendFormat("在{0}发生异常：{1}", this.CreateTime, this.ExceptionMessage);
                builder.AppendLine();
                builder.AppendFormat(this.ExceptionStackTrace);
                return builder.ToString() + base.Text;
            }
        }
    }
}
