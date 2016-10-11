using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LogInfo
    {
        public string time { get; set; }
        public LogLevel level { get; set; }
        public string message { get; set; }

        public LogInfo(string time, LogLevel level, string message)
        {
            this.time = time;
            this.level = level;
            this.message = message;
        }
    }
}
