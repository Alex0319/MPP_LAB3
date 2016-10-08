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
        private object monitorObj=new object();
        
        public Logger(int bufferLimit, ILoggerTarget[] target)
        {
            this.bufferLimit = bufferLimit;
            this.target = target;
        }

        public void Log(LogInfo logInfo)
        {
            Monitor.Enter(monitorObj);
            for (int i = 0; i < target.Length; i++)
                target[i].Flush(logInfo);
                Monitor.Exit(monitorObj);
        }
    }
}
