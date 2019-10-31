using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Text;

namespace ATM_1.Writer
{
    class Writer : IWriter
    {
        private StreamWriter sw;
        public Writer(string path)
        {
            sw = File.CreateText(path);
        }
        public void WriteFile(ITrack track)
        {
            string path = "log.txt";
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("dk-DK");
            var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);

            sw = new StreamWriter(path);
            sw.WriteLine("Tag: " + track.Tag + ", X-Coordinate: " + track.xCoordinate + ", Y-Coordinate: " +
                             track.yCoordinate + ", Altitude: " + track.Altitude + ", Timestamp: " + track.TimeStamp);
        }

        public void WriteConsole(ITrack track)
        {
        const string dateFormat = "yyyyMMddHHmmssfff";
        CultureInfo cultureInfo = new CultureInfo("dk-DK");
        var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);

        Console.WriteLine("Tag: {0}, X-Coordinate: {1}, Y-Coordinate: {2}, Altitude: {3}, Timestamp: {4}",
                track.Tag, track.xCoordinate, track.yCoordinate, track.Altitude, timestamp);
        }

    }
}
