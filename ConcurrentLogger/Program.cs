using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            int bufferLimit=5;

            ILoggerTarget[] logTarget = new ILoggerTarget[] { new LoggerTargetFile("FileLog.txt") };
            var controller = new ThreadPoolEvents(new Logger(bufferLimit, logTarget));
            controller.ThreadPoolLogging();
            Console.ReadKey();
        }
    }
}
