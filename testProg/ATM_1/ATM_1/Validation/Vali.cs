using System;

namespace ATM_1
{
    public class Vali : IVali
    {
        readonly IAirSpace _airSpace; 
        public Vali(IAirSpace airSpace)
        {
            _airSpace = airSpace;
        }


        public bool Validate(ITrack track)
        {
            // Compare
            bool altitude = (track.Altitude >= _airSpace._LowerBoundary && track.Altitude <= _airSpace._UpperBoundary);
            bool x = (track.xCoordinate <= _airSpace._X && track.xCoordinate >= 0);
            bool y = (track.yCoordinate <= _airSpace._Y && track.yCoordinate >= 0);
            return (altitude && x && y);
        }
    }
}
