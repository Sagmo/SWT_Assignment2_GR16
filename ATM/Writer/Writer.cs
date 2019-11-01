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
    public class Writer : IWriter
    {
        private StreamWriter _sw;
        public Writer(string path)
        {
            _sw = File.CreateText(path);
            _sw.Close();
            _sw = new StreamWriter(path);
        }
        public void WriteFile(List<ITrack> list)
        {
            string path = "log.txt";
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            var timestamp = DateTime.ParseExact(list[0].TimeStamp, dateFormat, cultureInfo);
            _sw.WriteLine($"[{list[0].Tag}]\t" + $"[{list[1].Tag}]\t" + $"[{timestamp}]\t");
            _sw.Flush();
        }

        public void WriteConsole(List<ITrack> list)
        {
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");

            Console.Clear();
            foreach (ITrack track in list)
            {
                var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);
                Console.WriteLine($"[{track.Tag}]\t" +
                                  $"[{track.xCoordinate}:{track.yCoordinate}]\t" +
                                  $"[{track.Altitude}]\t" +
                                  $"[{timestamp}]\t");
            }
        }

        public void WriteSeperationConsole(List<ITrack> list)
        {
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, dateFormat, cultureInfo);
            var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, dateFormat, cultureInfo);
            Console.Clear();
            Console.WriteLine("Seperation: Tag1: {0}, Tag2: {1}, Timestamp1: {2}, Timestamp2: {3}", list[0].Tag, list[1].Tag,
                timestamp1, timestamp2);
        }

    }
}
