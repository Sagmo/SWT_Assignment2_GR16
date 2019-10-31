using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_1
{
    interface IWriter
    {
        void WriteFile(ITrack track);
        void WriteConsole(ITrack track);

        void WriteSeperationConsole(List<ITrack> list);
    }
}
