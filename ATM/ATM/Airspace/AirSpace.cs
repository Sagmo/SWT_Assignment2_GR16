using System;


namespace ATM_1
{
    public class AirSpace : IAirSpace
    {
        public AirSpace(double x, double y, double lowerBoundary, double upperBoundary)
        {
            _X = x;
            _Y = y;
            _LowerBoundary = lowerBoundary;
            _UpperBoundary = upperBoundary;
        }

        public double _X { set; get; }
        public double _Y { set; get; }
        public double _LowerBoundary { set; get; }
        public double _UpperBoundary { set; get; }
    }
}
