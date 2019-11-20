using System;


namespace ATM_1
{
    public class AirSpace : IAirSpace
    {
        public AirSpace(double minX, double maxX, double minY, double maxY, double lowerBoundary, double upperBoundary)
        {
            _MinX = minX > 0 ? minX : throw new Exception("Too Small Airspace");
            _MaxX = maxX > 0 ? maxX : throw new Exception("Too Small Airspace");
            _MinY = minY > 0 ? minY : throw new Exception("Too Small Airspace");
            _MaxY = maxY > 0 ? maxY : throw new Exception("Too Small Airspace");
            _LowerBoundary = lowerBoundary > 0 ? lowerBoundary : throw new Exception("Too Small Airspace");
            _UpperBoundary = upperBoundary > 0 ? upperBoundary : throw new Exception("Too Small Airspace");

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
