using System;

namespace ATM_1
{
    public interface ILog
    {
        void WriteFile(string writeData);
        void WriteConsole(string writeData);
    }
}
