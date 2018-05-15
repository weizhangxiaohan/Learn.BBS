using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Learn.Common
{
    public class ValidateCodeGenerator
    {
        public static ValidateCodeGenerator _default;

        public static ValidateCodeGenerator Default
        {
            get
            {
                if (_default == null)
                {
                    var generator = new ValidateCodeGenerator()
                    {
                        ImageWidth = 200,
                        ImageHeight = 60,
                        CodeLength = 4
                    };
                    _default = generator;
                }

                return _default;
            }
        }


        public int ImageWidth { get; set; }
        public int ImageHeight { get; set; }

        public string Letters { get; set; }
        public int CodeLength { get; set; }

        private Random r = new Random();

        public ValidateCodeGenerator()
        {
            Letters = "ABCDEFGHJKLMNPQRSTUVWXYZ1234567890";
        }

        private string GetValidationCode()
        {
            //合法随机显示字符列表
            var builder = new StringBuilder();
            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < CodeLength; i++)
            {
                builder.Append(Letters.Substring(r.Next(0, Letters.Length - 1), 1));
            }
            return builder.ToString();
        }

        public ValidateCode GetValidateCode()
        {
            var validateCode = new ValidateCode();
            string code =  GetValidationCode();
            validateCode.Code = code;

            //设置输出流图片格式
            var bitMap = new Bitmap(ImageWidth, ImageHeight);
            var g = Graphics.FromImage(bitMap);

            int ColorR = r.Next(0, 255);
            int ColorG = r.Next(0, 255);
            int ColorB = r.Next(0, 255);

            g.FillRectangle(new SolidBrush(Color.FromArgb(ColorR, ColorG, ColorB)), 0, 0, 200, 60);

            var font = new Font(FontFamily.GenericSerif, 48, FontStyle.Bold, GraphicsUnit.Pixel);
            //合法随机显示字符列表
            //将随机生成的字符串绘制到图片上
            for (int i = 0; i < code.Length; i++)
            {
                int sR = r.Next(0, 255);
                int sG = r.Next(0, 255);
                int sB = r.Next(0, 255);
                while (Math.Abs(sR - ColorR) < 35) sR = r.Next(0, 255);
                while (Math.Abs(sG - ColorG) < 35) sG = r.Next(0, 255);
                while (Math.Abs(sB - ColorB) < 35) sB = r.Next(0, 255);
                g.DrawString(code[i].ToString(), font, new SolidBrush(Color.FromArgb(sR, sG, sB)), i * (200 / code.Length - 2), r.Next(0, 15));
            }
            //生成干扰线条
            var pen = new Pen(new SolidBrush(Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))), 2);
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(pen, new Point(r.Next(0, 199), r.Next(0, 59)), new Point(r.Next(0, 199), r.Next(0, 59)));
            }
            var stream = new System.IO.MemoryStream();
            bitMap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            g.Dispose();
            bitMap.Dispose();
            //输出图片流

            validateCode.Image = stream.ToArray();
            return validateCode;
        }
    }

    public class ValidateCode
    {
        public string Code { get; set; }
        public byte[] Image { get; set; }
    }
}
