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
