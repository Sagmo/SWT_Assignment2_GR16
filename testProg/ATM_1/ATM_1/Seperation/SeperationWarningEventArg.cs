using System;
using System.Collections.Generic;

namespace ATM_1
{
    public class SeperationWarningEventArgs : EventArgs
    {
        public ITrack track { get; set; }
    }
}
