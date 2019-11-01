using System;


namespace ATM_1
{
    public interface ITrack
    {
        //public void FlightTrack(string tag, string xCoo, string yCoo, string altitude, string timeStamp);
        string Tag         { get; set; }
        double xCoordinate { get; set; }
        double yCoordinate { get; set; }
        double Altitude    { get; set; }
        string TimeStamp   { get; set; }

        double HorizontalVelocity { get; set; }
        double CompassCourse      { get; set; }
    }
}
