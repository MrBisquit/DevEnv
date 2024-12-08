using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEnv.Core
{
    public static class EngineManagement
    {
        public class EngineStatus
        {
            public enum Status
            {
                Online = 0,
                Starting = 1,
                Offline = 2
            }

            public Status status;
            public string text = string.Empty;
        }
    }
}
