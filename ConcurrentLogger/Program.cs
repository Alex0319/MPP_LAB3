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
            int bufferLimit=3;
            
            ILoggerTarget[] logTarget = new ILoggerTarget[] { new LoggerTargetWriteToFile()};
            var controller = new ThreadPoolEvents(new Logger(bufferLimit, logTarget));
            controller.ThreadPoolLogging();
            Console.ReadKey();
            controller.SetEndOfLogging();
        }
    }
}
