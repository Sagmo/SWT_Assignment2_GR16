using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_1.Writer
{
    interface IWriter
    {
        void WriteFile(ITrack track);
        void WriteConsole(ITrack track);
    }
}
