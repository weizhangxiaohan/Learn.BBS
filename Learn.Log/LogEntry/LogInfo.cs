using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log.LogEntry
{
    public abstract class LogInfo
    {
        private LogType _type;
        private string _text;
        private DateTime _createTime;
        private string _creator;

        public virtual string Text
        {
            get
            {
                if (_text == null)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine();
                    builder.AppendFormat("当前用户：{0}", _creator);
                    builder.AppendLine();
                    builder.AppendFormat("当前时间：{0}", _createTime);
                    _text = builder.ToString();
                }
                return _text;
            }
        }
        public virtual LogType Type
        {
            get
            {
                return _type;
            }
        }
        public DateTime CreateTime
        {
            get => _createTime;
            set => _createTime = value;
        }
        public string Creator
        {
            get => _creator;
            set => _creator = value;
        }

        public abstract string GetDirectoryName();
        public override string ToString()
        {
            return Text;
        }
    }
}
