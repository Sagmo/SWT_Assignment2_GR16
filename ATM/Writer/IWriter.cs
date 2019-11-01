using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_1
{
    interface IWriter
    {
        void WriteFile(List<ITrack> list);
        void WriteConsole(List<ITrack> list);

        void WriteSeperationConsole(List<ITrack> list);
    }
}
