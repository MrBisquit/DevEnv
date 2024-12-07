using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace WindowsEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting DevEnv Windows engine...");

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Platform is not Windows, stopping...");
                Environment.Exit(-1);
                return;
            }

            Console.WriteLine("Starting named pipe instance...");
            var server = new NamedPipeServerStream("DevEnv_Engines_WindowEngine_Pipe");
            Console.WriteLine("Awaiting connection on pipe \"DevEnv_Engines_WindowEngine_Pipe\"");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);
            while (true)
            {
                var line = reader.ReadLine();
                Console.WriteLine("Received: " + line);
                writer.WriteLine(String.Join("", line.Reverse()));
                writer.Flush();
            }
        }
    }
}
