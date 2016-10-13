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

            ILoggerTarget[] logTarget = new ILoggerTarget[] { new LoggerTargetFile("FileLog.txt"),new LoggerTargetUdp("127.0.0.1",9000,"127.0.0.1",10000) };
            var controller = new LogsCreator(new Logger(bufferLimit, logTarget));
            controller.CreateLogs(10000, LogLevel.Info);
            Console.ReadKey();
        }
    }
}
