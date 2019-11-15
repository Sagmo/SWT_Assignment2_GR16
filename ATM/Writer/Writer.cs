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
        const string DateFormat = "yyyyMMddHHmmssfff";
        readonly CultureInfo _cultureInfo = new CultureInfo("da-DK");
        public Writer(string path)
        {
            DateTime now = DateTime.Now;
            
            _sw = File.CreateText(path);
            _sw.Close();
            _sw = new StreamWriter(path);
        }
        public void WriteFile(List<ITrack> list)
        {
            
            var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, DateFormat, _cultureInfo);
            var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, DateFormat, _cultureInfo);
            _sw.WriteLine($"Seperation: [{list[0]} & {list[1].Tag}], [Timestamp1: {timestamp1}, Timestamp2: {timestamp2}]");
            _sw.Flush();
        }

        public void WriteConsole(List<ITrack> list)
        {
            Console.Clear();
            foreach (ITrack track in list)
            {
                var timestamp = DateTime.ParseExact(track.TimeStamp, DateFormat, _cultureInfo);
                Console.WriteLine($"[{track.Tag}]\t" +
                                  $"[{track.xCoordinate}:{track.yCoordinate}]\t" +
                                  $"[{track.Altitude} meters]\t" +
                                  $"[{track.CompassCourse} deg]\t" +
                                  $"[{track.HorizontalVelocity} m/s]\t" +
                                  $"[{timestamp}]\t");
            }
        }

        public void WriteSeperationConsole(List<ITrack> list)
        {
            var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, DateFormat, _cultureInfo);
            var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, DateFormat, _cultureInfo);

            Console.WriteLine($"Seperation: [{list[0]} & {list[1].Tag}], [Timestamp1: {timestamp1}, Timestamp2: {timestamp2}]");
            
        }

    }
}
