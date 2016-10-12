using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LoggerTargetFile: ILoggerTarget
    {
        private FileStream fileStream;
        private string filename;

        public LoggerTargetFile(string filename)
        {
            this.filename = filename;
        }

        public bool Flush(LogInfo logInfo)
        {
            Write(Encoding.Default.GetBytes(logInfo.ConvertToString().ToArray()));
            fileStream.Flush();
            fileStream.Close();
            fileStream.Dispose();
            return true;
        }

        public async Task<bool> FlushAsync(LogInfo logInfo)
        {
            Write(Encoding.Default.GetBytes(logInfo.ConvertToString().ToArray()));
            await fileStream.FlushAsync();
            fileStream.Close();
            fileStream.Dispose();
            return true;
        }

        public void Write(byte[] log)
        {
            fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write);
            fileStream.Write(log, 0, log.Length);
        }
    }
}
