using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_1
{
    public class Seperation : ISeperation
    {
        public ILog _logFile;
        public event EventHandler<SeperationWarningEventArgs> SeperationWarningEvent;
        
        
        public Seperation(ILog logFile, IDecoder decoder)
        {
            _logFile = logFile;
            decoder.DecodeEvent += handleDecodeEvent;
        }

        private void handleDecodeEvent(object sender, DecoderEventArgs e)
        {
            foreach (ITrack t in e.FlightObjectStruct.getlist())
            {
                
            }
        }

        public void CheckSeperation()
        {

        }

        protected virtual void OnSeperationWarning(SeperationWarningEventArgs e)
        {
            SeperationWarningEvent?.Invoke(this, e);
        }

    }
}
