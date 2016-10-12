using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class Logger: ILogger
    {
        private int bufferLimit;
        private ILoggerTarget[] target;
        private object locker=new object();
        private List<LogInfo> logInfoList;
        
        public Logger(int bufferLimit, ILoggerTarget[] target)
        {
            this.bufferLimit = bufferLimit;
            this.target = target;
            logInfoList = new List<LogInfo>();
        }

        public void Log(LogInfo logInfo)
        {
            if (logInfoList.Count == bufferLimit)
            {
                ThreadPool.QueueUserWorkItem(FlushLogsInAllTargets,logInfoList);
                logInfoList=new List<LogInfo>();
            }
            logInfoList.Add(logInfo);
        }

        private void FlushLogsInAllTargets(object objlogsList)
        {
            var logsList = (List<LogInfo>)objlogsList;
            Monitor.Enter(locker);
            try
            {
//                Monitor.Wait(locker);
                foreach (ILoggerTarget currentTarget in target)
                    foreach (LogInfo log in logsList)
                        currentTarget.Flush(log);
//                Monitor.PulseAll(locker);
            }
            finally 
            {
                Monitor.Exit(locker);
            }
        }
    }
}
