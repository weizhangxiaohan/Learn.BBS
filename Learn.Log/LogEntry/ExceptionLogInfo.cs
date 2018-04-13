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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine();
            builder.AppendFormat("在{0}发生异常：{1}",this.CreateTime,this._exceptionMessage);
            builder.AppendLine();
            builder.AppendFormat(this._exceptionStackTrace);
            builder.AppendLine();
            builder.Append("------------------------------------------------------------");
            return builder.ToString();
        }
    }
}