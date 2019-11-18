using System;


namespace ATM_1
{
    public class AirSpace : IAirSpace
    {
        public AirSpace(double minX, double maxX, double minY, double maxY, double lowerBoundary, double upperBoundary)
        {
            _MinX = minX;
            _MaxX = maxX;
            _MinY = minY;
            _MaxY = maxY;

            if ( ((_MaxX - _MinX) < 80000) || ((_MaxY - _MinY) < 80000) )
                throw new Exception("Too Small Airspace");

            _LowerBoundary = lowerBoundary;
            _UpperBoundary = upperBoundary;
        }

        public double _MinX { set; get; }
        public double _MinY { set; get; }
        public double _MaxX { set; get; }
        public double _MaxY { set; get; }
        public double _LowerBoundary { set; get; }
        public double _UpperBoundary { set; get; }
    }
}
