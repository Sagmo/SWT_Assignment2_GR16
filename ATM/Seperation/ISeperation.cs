using System;
using System.Collections.Generic;

namespace ATM_1
{
    public interface ISeperation
    {
        event EventHandler<SeperationWarningEventArgs> SeperationWarningEvent;
        void CheckSeperation(List<ITrack> e);
    }
}
