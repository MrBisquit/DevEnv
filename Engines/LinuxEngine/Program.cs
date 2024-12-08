using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace LinuxEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting DevEnv Linux engine...");

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Console.WriteLine("Platform is not Linux, stopping...");
                Environment.Exit(-1);
                return;
            }
            
            while(true)
            {
                Console.WriteLine("Starting named pipe instance...");
                var server = new NamedPipeServerStream("DevEnv_Engines_LinuxEngine_Pipe");
                Console.WriteLine("Awaiting connection on pipe \"DevEnv_Engines_LinuxEngine_Pipe\"");
                server.WaitForConnection();
                Console.WriteLine("Connected");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (server.IsConnected)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        Console.WriteLine("Received: " + line);
                        writer.WriteLine(String.Join("", line.Reverse()));
                        writer.Flush();
                    }
                    catch { }
                }
                server.Disconnect();
                server.Close();
                server.Dispose();
                Console.WriteLine("Disconnected");
            }
        }
    }
}