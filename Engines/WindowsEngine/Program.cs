using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace WindowsEngine
{
    internal class Program
    {
        // Definitions
        static KeyValuePair<string, Messages.Base>[] messages =
        {

        };

        static void Main(string[] args)
        {
            Console.WriteLine("Starting DevEnv Windows engine...");

            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Platform is not Windows, stopping...");
                Environment.Exit(-1);
                return;
            }

            while(true)
            {
                Console.WriteLine("Starting named pipe instance...");
                var server = new NamedPipeServerStream("DevEnv_Engines_WindowsEngine_Pipe");
                Console.WriteLine("Awaiting connection on pipe \"DevEnv_Engines_WindowsEngine_Pipe\"");
                server.WaitForConnection();
                Console.WriteLine("Connected");
                StreamReader reader = new StreamReader(server);
                StreamWriter writer = new StreamWriter(server);
                while (server.IsConnected)
                {
                    try
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            Console.WriteLine("Received: " + line);
                            if (line == "ping")
                            {
                                writer.WriteLine("pong");
                            }

                            string[] split = line.Split(';');
                            if(split.Length >= 2)
                            {
                                for (int i = 0; i < messages.Length; i++)
                                {
                                    if (messages[i].Key == split[i])
                                    {
                                        messages[i].Value.Run(split[1]);
                                    }
                                }
                            }
                        }
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
