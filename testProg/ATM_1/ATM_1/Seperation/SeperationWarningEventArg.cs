using System;
using System.Collections.Generic;

namespace ATM_1
{
    public class SeperationWarningEventArgs : EventArgs
    {
        public List<ITrack> SeperationList { get; set; }
    }
}
