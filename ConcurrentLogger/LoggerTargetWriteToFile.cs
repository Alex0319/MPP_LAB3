using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LoggerTargetWriteToFile: ILoggerTarget
    {
        public bool Flush(LogInfo logInfo)
        {
            Task<bool> t= FlushAsync(logInfo);
            return t.Result;
        }

        public Task<bool> FlushAsync(LogInfo logInfo)
        {
            return Task.Run<bool>(()=> {
                StreamWriter streamWriter = new StreamWriter("FileLog.txt", true);    
                try
                {
                    streamWriter.WriteLine(logInfo.level+" "+logInfo.message);
                }
                finally
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
                return true;
            });         
        }
    }
}
