using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEngine.Messages
{
    public abstract class Base
    {
        public abstract string Name { get; }
        public abstract string Description { get; }

        public virtual void Run(string data)
        {
            /**
             * Steps:
             * - Download list from API including instructions on how to find each of them
             * - Go through each of them, create a list of all of the ones that are installed in a JSON file
             * - Update via progress updates every step, intermediate when downloading the list from the API
             * - At the end send a progress update with the value 100% to tell the GUI or CLI that it is complete
             * */
        }
    }
}
