using System;

namespace ConcurrentLogger
{
    public class LogInfo
    {
        public LogLevel level { get; set; }
        public string message { get; set; }

        private string time;

        public LogInfo(LogLevel level, string message)
        {
            this.level = level;
            this.message = message;
            time = DateTime.Now.ToString();
        }

        public string ConvertToString()
        {
            return String.Format("[ {0} ] {1} {2}{3}",time, level, message,Environment.NewLine);
        }
    }
}
