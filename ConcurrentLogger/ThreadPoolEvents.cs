using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class ThreadPoolEvents
    {
        private Logger logger;

        public ThreadPoolEvents(Logger logger)
        {
            this.logger = logger;
        }

        public void ThreadPoolLogging()
        {
            for (int i = 0; i < 10000; i++)
                logger.Log(new LogInfo(LogLevel.Info, "task " + i));
            logger.FlushRemainLogs();
        }
    }
}
