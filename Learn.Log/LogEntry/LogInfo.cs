using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Log
{
    public class LogInfo
    {
        public LogType _type;

        public string _text;

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public LogType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
    }
}
