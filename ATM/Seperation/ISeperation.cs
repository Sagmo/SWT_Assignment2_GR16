using System;

namespace ATM_1
{
    public interface ISeperation
    {
        event EventHandler<SeperationWarningEventArgs> SeperationWarningEvent;
    }
}