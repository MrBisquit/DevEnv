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
        }
    }
}
