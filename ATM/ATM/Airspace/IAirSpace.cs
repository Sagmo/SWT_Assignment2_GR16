using System;

namespace ATM_1
{
    public interface IAirSpace
    {
        //void AirSpace(double x, double y, double lowerBoundary, double upperBoundary); 
        double _X             { set; get; }
        double _Y             { set; get; }
        double _LowerBoundary { set; get; }
        double _UpperBoundary { set; get; }
    }
}
