using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEngine.Messages
{
    public class Scan : Base
    {
        public override string Name => "Scan";
        public override string Description => "Scans the computer for IDEs/Editors/Frameworks/Compilers/Interpreters/Etc...";

        public override async void Run(string data)
        {
            /**
             * Steps:
             * - Download list from API including instructions on how to find each of them
             * - Go through each of them, create a list of all of the ones that are installed in a JSON file
             * - Update via progress updates every step, intermediate when downloading the list from the API
             * - At the end send a progress update with the value 100% to tell the GUI or CLI that it is complete
             * */

            Console.WriteLine("Starting scan");

            DevEnv.Core.Config config = new DevEnv.Core.Config();

            using (HttpClient client = new HttpClient()) {
                Console.WriteLine("Requesting scanning information");
                Sending.SendProgressUpdate(message: "Requesting scanning information", intermediate: true);
                HttpResponseMessage response = await client.GetAsync(config.APILocation + "/scanning/");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Received scanning information");
                    Sending.SendProgressUpdate(message: "Received scanning information");
                } else
                {
                    Console.WriteLine("Scan failed: Failed to fetch scanning information");
                    Sending.SendError("Scan failed: Failed to fetch scanning information", true);
                }
            }
        }
    }
}
