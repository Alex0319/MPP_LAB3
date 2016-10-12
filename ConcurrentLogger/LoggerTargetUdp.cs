using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public class LoggerTargetUdp:ILoggerTarget
    {
        private string ip;
        private int port;
        private UdpClient udpClient;

        public LoggerTargetUdp(string ip,int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public bool Flush(LogInfo logInfo)
        {
            Write(Encoding.Default.GetBytes(logInfo.ConvertToString().ToArray()));
            udpClient.Close();
            return true;
        }

        public async Task<bool> FlushAsync(LogInfo logInfo)
        {
            return true;
        }

        public void Write(byte[] log)
        {
            try
            {
                udpClient = new UdpClient(ip, port);
                udpClient.Send(log, log.Length);
            }
            finally 
            {
                udpClient.Close();
            }
        }
    }
}
