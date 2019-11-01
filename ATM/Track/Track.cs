using System;
using System.Collections.Generic;


namespace ATM_1
{
    public class Track : ITrack
    {
        public Track(string tag, string xCoo, string yCoo, string altitude, string timeStamp)
        {
            Tag         = tag;
            xCoordinate = Convert.ToDouble(xCoo);
            yCoordinate = Convert.ToDouble(yCoo);
            Altitude    = Convert.ToDouble(altitude);
            TimeStamp   = timeStamp;

            HorizontalVelocity = 0;
            CompassCourse      = 0;
        }

        public string Tag         { get; set; }
        public double xCoordinate { get; set; }
        public double yCoordinate { get; set; }
        public double Altitude    { get; set; }
        public string TimeStamp   { get; set; }

        public double HorizontalVelocity { get; set; }
        public double CompassCourse      { get; set; }
    }
}
