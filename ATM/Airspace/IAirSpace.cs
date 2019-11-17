using System;

namespace ATM_1
{
    public interface IAirSpace
    {
        //void AirSpace(double x, double y, double lowerBoundary, double upperBoundary); 
        double _MinX { set; get; }
        double _MinY { set; get; }
        double _MaxX { set; get; }
        double _MaxY { set; get; }
        double _LowerBoundary { set; get; }
        double _UpperBoundary { set; get; }
    }
}
