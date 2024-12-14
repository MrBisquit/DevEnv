using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEngine
{
    public static class Sending
    {
        public static void SendProgressUpdate(int value = 0, string message = "", bool intermediate = false)
        {
            Program.writer.WriteLine("progress;" + JsonConvert.SerializeObject(new DevEnv.Engine.Core.ProgressMessage() { Value = value, Message = message, Intermediate = intermediate }));
            Program.writer.Flush();
        }

        public static void SendError(string message = "", bool critical = false)
        {
            Program.writer.WriteLine("error;" + JsonConvert.SerializeObject(new DevEnv.Engine.Core.ErrorMessage() { Message = message, Critical = critical }));
            Program.writer.Flush();
        }
    }
}
