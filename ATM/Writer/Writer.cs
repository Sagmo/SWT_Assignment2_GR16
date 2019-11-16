using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ATM_1
{
    public class Writer : IWriter
    {
        private StreamWriter _sw;
        private readonly string _path;
        const string DateFormat = "yyyyMMddHHmmssfff";
        readonly CultureInfo _cultureInfo = new CultureInfo("da-DK");
        public Writer(string path)
        {
            _path = path;
            _sw = File.CreateText(_path);
            _sw.Close();
            
        }
        public void WriteFile(List<ITrack> list)
        {
            if (list.Count > 0)
            {
                _sw = File.AppendText(_path);
                var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, DateFormat, _cultureInfo);
                var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, DateFormat, _cultureInfo);
                _sw.WriteLine(
                    $"Seperation: [{list[0].Tag} & {list[1].Tag}], [Timestamp1: {timestamp1}, Timestamp2: {timestamp2}]");
                _sw.Flush();
                _sw.Close();
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(list));
            }
        }

        public void WriteConsole(List<ITrack> list)
        {
            if (!Console.IsOutputRedirected) Console.Clear();
            if (list.Count > 0)
            {
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
            else
            {
                throw new ArgumentOutOfRangeException(nameof(list));
            }
        }

        public void WriteSeperationConsole(List<ITrack> list)
        {
            if (list.Count > 0)
            {
                var timestamp1 = DateTime.ParseExact(list[0].TimeStamp, DateFormat, _cultureInfo);
                var timestamp2 = DateTime.ParseExact(list[1].TimeStamp, DateFormat, _cultureInfo);
                Console.WriteLine(
                    $"Seperation: [{list[0].Tag} & {list[1].Tag}], [Timestamp1: {timestamp1}, Timestamp2: {timestamp2}]");
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(list));
            }
        }

    }
}
