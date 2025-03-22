using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Functions
{
    public static class Scan
    {
        public static void StartScan()
        {
            Console.WriteLine("Attempting to connect to engine...");
            DevEnv.Core.Pipe.Initialise();
            if (DevEnv.Core.Pipe.IsConnected)
            {
                Console.WriteLine("Connected, running scan");
                DevEnv.Core.Pipe.writer.WriteLine("scan;");
                DevEnv.Core.Pipe.writer.Flush();

                bool running = true;

                while(running)
                {
                    string response = DevEnv.Core.Pipe.reader.ReadLine();
                    Console.WriteLine(response);
                }
            } else
            {
                Console.WriteLine("Could not connect, engine may be offline or busy");
                return;
            }
        }
    }
}
