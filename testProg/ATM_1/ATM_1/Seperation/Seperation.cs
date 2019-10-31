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
            decoder.DecodeEvent += HandleDecodeEvent;
        }

        private void HandleDecodeEvent(object sender, DecoderEventArgs e)
        {
            CheckSeperation(e.FlightObjectStruct.getlist());
        }

        public void CheckSeperation(List<ITrack> e)
        {
            foreach (var track in e)
            {
                foreach (var otherTrack in e)
                {
                    if (track.Tag == otherTrack.Tag) continue;

                    var delta = new
                    {
                        X = track.xCoordinate - otherTrack.xCoordinate,
                        Y = track.yCoordinate - otherTrack.yCoordinate,
                    };

                    var distance = new
                    {
                        Horizontal = Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2)),
                        Vertical = Math.Abs(track.Altitude - otherTrack.Altitude)
                    };

                    if (distance.Horizontal < 5000 && distance.Vertical < 300)
                    {
                        var flightsInSeparation = new List<ITrack>() { track, otherTrack };
                        OnSeperationWarning(new SeperationWarningEventArgs { SeperationList = flightsInSeparation });
                    }
                }
            }
        }

        protected virtual void OnSeperationWarning(SeperationWarningEventArgs e)
        {
            SeperationWarningEvent?.Invoke(this, e);
        }

    }
}
