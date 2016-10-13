using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LogsCreator
    {
        private Logger logger;

        public LogsCreator(Logger logger)
        {
            this.logger = logger;
        }

        public void CreateLogs(int logsCount,LogLevel level)
        {
            for (int i = 0; i < logsCount; i++)
                logger.Log(new LogInfo(level, "task " + i));
            logger.FlushRemainLogs();
        }
    }
}
