using Learn.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.utility
{
    public class ValidateCodeHelper
    {
        public static ValidateCode GetValidateCode(ValidateCodeGenerator generator)
        {
            return generator.GetValidateCode();
        }

        public static ValidateCode GetValidateCode()
        {
            return GetValidateCode(ValidateCodeGenerator.Default);
        }
    }
}
