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
            bool x = (track.xCoordinate <= _airSpace._MaxX && track.xCoordinate >= _airSpace._MinX);
            bool y = (track.yCoordinate <= _airSpace._MaxY && track.yCoordinate >= _airSpace._MinY);
            return (altitude && x && y);
        }
    }
}
