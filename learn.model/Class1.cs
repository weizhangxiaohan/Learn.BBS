using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace learn.model
{
    public class Class1
    {
        public async Task<string> GetString()
        {
            WebClient client = new WebClient();
            Task<string> t = client.DownloadStringTaskAsync("http://www.baidu.com");
            int a = 1;
            int b = 2;
            int c = 1 + 2;
            string s = await t;
            //s = t.Result;
            s = s.Trim();
            return s;
        }

        public async Task<string> GetString1()
        {
            string s = await this.GetString();
            return s;
        }

        public async Task<string> GetString2()
        {
            string s = await this.GetString1();
            return s;
        }

        public string BeginGetString()
        {
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri("http:www.baidu.com"));
            //IAsyncResult response = request.BeginGetResponse(null,null);
            //while (!response.IsCompleted)
            //{
            //    Console.Write(".");
            //    Console.Write(Thread.CurrentThread.ThreadState.ToString());
            //}
            //Stream stream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            //return reader.ReadToEnd();            

            return "";
        }
    }
}
