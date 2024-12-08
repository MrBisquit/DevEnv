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

        }
    }
}
