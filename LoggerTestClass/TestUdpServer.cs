using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LoggerTestClass
{
    public class TestUdpServer
    {
        private UdpClient udpClient;
        private string serverIP;
        private int serverPort;
        private StringBuilder stringBuilder;
        private volatile bool isReadSocket;
        private Task receiveAsync;

        public TestUdpServer(string serverIP,int serverPort)
        {
            stringBuilder = new StringBuilder();
            this.serverIP = serverIP;
            this.serverPort = serverPort;
        }

        public void StartReceive()
        {
            isReadSocket = true;
            udpClient = new UdpClient(serverIP, serverPort);
            receiveAsync = Task.Factory.StartNew(() => TaskReceive());
        }

        public async void TaskReceive()
        {
            int count = 0;
            while (isReadSocket)
            {
                var receiveBytes = await udpClient.ReceiveAsync();
                stringBuilder.Append(count++);                
            }
        }

        public void Synchronize()
        {
            isReadSocket = false;
            receiveAsync.Wait();
            receiveAsync.Dispose();
            receiveAsync = null;
        }

        public byte[] GetMessage()
        {
            return Encoding.Default.GetBytes(stringBuilder.ToString());
        }

        public void Close()
        {
            udpClient.Close();
        }

    }
}
