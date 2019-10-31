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
            foreach (var track in e.FlightObjectStruct.getlist())
            {
                foreach (var otherTrack in e.FlightObjectStruct.getlist())
                {
                    if (track.Tag == otherTrack.Tag) continue;

                    var delta = new
                    {
                        X = track.xCoordinate - otherTrack.XPosition,
                        Y = track.YPosition - otherTrack.YPosition,
                    };

                    var distance = new
                    {
                        Horizontal = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2)),
                        Vertical = Math.Abs(track.Altitude - otherTrack.Altitude)
                    };

                    if (distance.Horizontal < 5000 && distance.Vertical < 300)
                    {
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
