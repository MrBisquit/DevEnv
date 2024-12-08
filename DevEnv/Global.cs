using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEnv
{
    public static class Global
    {
        public enum Platform
        {
            Windows = 0,
            Linux = 1,
            OSX = 2,
            FreeBSD = 3
        };
        
        public static Platform platform;

        public static Core.Config config;
    }
}
