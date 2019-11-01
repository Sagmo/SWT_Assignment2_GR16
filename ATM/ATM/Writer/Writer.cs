using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Runtime.CompilerServices;
using System.Linq;

namespace ATM_1
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
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);

            sw = new StreamWriter(path);
            sw.WriteLine($"{track.Tag}\t" +
                         $"[{track.xCoordinate}:{track.yCoordinate}]\t" +
                         $"[{track.Altitude}]\t" +
                         $"[{track.TimeStamp}]\t");
            sw.Close();
        }

        public void WriteConsole(ITrack track)
        {
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);

            Console.WriteLine($"{track.Tag}\t" +
                              $"[{track.xCoordinate}:{track.yCoordinate}]\t" +
                              $"[{track.Altitude}]\t" +
                              $"[{track.TimeStamp}]\t");
        }

        public void WriteSeperationConsole(List<ITrack> list)
        {
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, dateFormat, cultureInfo);
            var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, dateFormat, cultureInfo);

            Console.WriteLine("Seperation: Tag1: {0}, Tag2: {1}, Timestamp1: {2}, Timestamp2: {3}", list[0], list[1],
                timestamp1, timestamp2);
        }

    }
}
