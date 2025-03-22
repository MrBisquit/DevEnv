namespace CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DevEnv.Core.Config config = new DevEnv.Core.Config();
            config.LoadConfig();

            if(args.Length == 0)
            {
                // Start in CLI mode

                Console.WriteLine("Checking if engine is online...");
                Console.WriteLine("Attempting to connect to engine...");
                DevEnv.Core.Pipe.Initialise();
                if(DevEnv.Core.Pipe.IsConnected)
                {
                    Console.WriteLine("Connected successfully");
                    Console.WriteLine("Pinging");
                    DevEnv.Core.Pipe.writer.WriteLine("ping");
                    DevEnv.Core.Pipe.writer.Flush();
                    string message = DevEnv.Core.Pipe.reader.ReadLine();
                    if(message == "pong")
                    {
                        Console.WriteLine("Received pong");
                    } else
                    {
                        Console.WriteLine("Did not receive pong");
                    }

                    Console.WriteLine("Disconnecting...");
                    DevEnv.Core.Pipe.Disconnect();
                } else
                {
                    Console.WriteLine("Could not connect, engine may be offline or busy");
                }

                while(true)
                {
                    Console.Write($"DevEnv CLI $ ");
                    string command = Console.ReadLine();
                    if (command == "") continue;
                    else if(command == "exit") Environment.Exit(0);

                    Main(command.Split(' '));
                }
            } else
            {
                switch(args[0])
                {
                    case "scan":
                        Functions.Scan.StartScan();
                        break;
                }
                // Parse the provided arguments
            }
        }
    }
}
