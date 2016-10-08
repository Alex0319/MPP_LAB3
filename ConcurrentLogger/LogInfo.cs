using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LogInfo
    {
        public LogLevel level { get; set; }
        public string message { get; set; }
    }
}
