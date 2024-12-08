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
                    Console.WriteLine("Disconnecting...");
                } else
                {
                    Console.WriteLine("Could not connect, engine may be offline or busy");
                }

                while(true)
                {
                    Console.Write($"DevENV CLI $ ");
                    string command = Console.ReadLine();
                    if (command == "") continue;
                    else if(command == "exit") Environment.Exit(0);

                    Main(command.Split(' '));
                }
            } else
            {
                // Parse the provided arguments
            }
        }
    }
}
