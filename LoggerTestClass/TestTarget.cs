using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ConcurrentLogger;

namespace LoggerTestClass
{
    public class TestTarget: ILoggerTarget
    {
        private MemoryStream memStream;
        private StringBuilder message = new StringBuilder();

        public TestTarget()
        {
            memStream = new MemoryStream();
        }

        public void Write(LogInfo logInfo)
        {
            message.Append(logInfo.message.Substring(5));
            byte[] log=Encoding.Default.GetBytes(logInfo.ConvertToString().ToArray());
            memStream.Write(log, 0, log.Length);
        }

        public bool Flush(LogInfo logInfo)
        {
            Write(logInfo);
            memStream.Flush();
            return true;
        }

        public async Task<bool> FlushAsync(LogInfo logInfo)
        {
            Write(logInfo);
            await memStream.FlushAsync();
            return true;
        }

        public byte[] GetMessage()
        {
            return Encoding.Default.GetBytes(message.ToString()); 
        }

        public void Close()
        {
            memStream.Close();
            memStream.Dispose();
        }
    }
}
