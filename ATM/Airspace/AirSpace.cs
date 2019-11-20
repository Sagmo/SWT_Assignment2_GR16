using System;


namespace ATM_1
{
    public class AirSpace : IAirSpace
    {
        public AirSpace(double minX, double maxX, double minY, double maxY, double lowerBoundary, double upperBoundary)
        {
            _MinX = minX > 0 ? minX : throw new ArgumentOutOfRangeException(nameof(minX));
            _MaxX = maxX > 0 ? maxX : throw new ArgumentOutOfRangeException(nameof(maxX));
            _MinY = minY > 0 ? minY : throw new ArgumentOutOfRangeException(nameof(minY));
            _MaxY = maxY > 0 ? maxY : throw new ArgumentOutOfRangeException(nameof(maxY));
            _LowerBoundary = lowerBoundary > 0 ? lowerBoundary : throw new ArgumentOutOfRangeException(nameof(lowerBoundary));
            _UpperBoundary = upperBoundary > 0 ? upperBoundary : throw new ArgumentOutOfRangeException(nameof(upperBoundary));

            if ( ((_MaxX - _MinX) < 80000) || ((_MaxY - _MinY) < 80000))
                throw new Exception("Too Small Airspace");
        }

        public double _MinX { set; get; }
        public double _MinY { set; get; }
        public double _MaxX { set; get; }
        public double _MaxY { set; get; }
        public double _LowerBoundary { set; get; }
        public double _UpperBoundary { set; get; }
    }
}
