using System;

namespace ATM_1
{
    public interface IAirSpace
    {
        //void AirSpace(double x, double y, double lowerBoundary, double upperBoundary); 
        public double _X             { set; get; }
        public double _Y             { set; get; }
        public double _LowerBoundary { set; get; }
        public double _UpperBoundary { set; get; }
    }
}
