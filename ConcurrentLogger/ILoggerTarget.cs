﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentLogger
{
    public interface ILoggerTarget
    {
        bool Flush(LogInfo logInfo);
        Task<bool> FlushAsync(LogInfo logInfo);
        void Close();
    }
}
