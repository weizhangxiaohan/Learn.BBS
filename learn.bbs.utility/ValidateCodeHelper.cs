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

        public static ValidateCode GetValidateCode(int imageHeight,int imageWidth,int codeLength)
        {
            var generator = new ValidateCodeGenerator();
            generator.ImageHeight = imageHeight;
            generator.ImageWidth = imageWidth;
            generator.CodeLength = codeLength;
            return GetValidateCode(generator);
        }
    }
}
