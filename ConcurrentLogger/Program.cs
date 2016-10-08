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
            
            DateTime date = DateTime.Now;
            string dateString = date.ToString("\n%d \n");           
            ILoggerTarget[] logTarget = new ILoggerTarget[] { new LoggerTargetWriteToFile()};
            Logger logger=new Logger(bufferLimit, logTarget);
            Console.ReadKey();
        }
    }
}
