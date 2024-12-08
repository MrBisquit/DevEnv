using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace DevEnv.Core
{
    /// <summary>
    /// Connecting to the engine via a named pipe
    /// </summary>
    public static class Pipe
    {
        public static NamedPipeClientStream client;
        public static StreamReader reader;
        public static StreamWriter writer;

        public static bool IsConnected = false;

        public static void Initialise()
        {
            string pipeName = "";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // Windows
                pipeName = "DevEnv_Engines_WindowsEngine_Pipe";
            } else if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Linux
                pipeName = "DevEnv_Engines_LinuxEngine_Pipe";
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // OSX
                return;
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD))
            {
                // FreeBSD
                return;
            } else
            {
                // Unsupported
                return;
            }

            Config config = new Config();
            config.LoadConfig();

            client = new NamedPipeClientStream(pipeName);
            try
            {
                client.Connect(config.PipeConnectionTimeout);
            } catch(TimeoutException timeout)
            {
                // Not really much to do
            }

            if(client.IsConnected)
            {
                IsConnected = true;

                reader = new StreamReader(client);
                writer = new StreamWriter(client);
            } else
            {
                IsConnected = false;
            }
        }

        public static void Reconnect()
        {
            Disconnect();
            Initialise();
        }

        public static void Disconnect()
        {
            client.Close();
            client.Dispose();
        }
    }
}
