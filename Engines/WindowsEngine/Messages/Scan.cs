using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEngine.Messages
{
    public class Scan : Base
    {
        public override string Name => "Scan";
        public override string Description => "Scans the computer for IDEs/Editors/Frameworks/Compilers/Interpreters/Etc...";

        public override void Run(string data)
        {
            // Fetch, save and then use scanning data
        }
    }
}
