using System;
using System.Text;
using ConcurrentLogger;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoggerTestClass
{
    [TestClass]
    public class LoggerTest
    {

        [TestMethod]
        public void TestMethod_TestOneTarget()
        {
            int bufferLimit=5, logsCount=10000;
            TestTarget testTarget = new TestTarget();
            StringBuilder stringBuilder = new StringBuilder();
            ILoggerTarget[] logTarget = new ILoggerTarget[] { testTarget };
            var controller = new LogsCreator(new Logger(bufferLimit, logTarget));
            controller.CreateLogs(logsCount);
            for (int i = 0; i < logsCount; i++)
                stringBuilder.Append(i);
            CollectionAssert.AreEqual(Encoding.Default.GetBytes(stringBuilder.ToString()),testTarget.GetMessage());
            testTarget.Close();
        }
    }
}
