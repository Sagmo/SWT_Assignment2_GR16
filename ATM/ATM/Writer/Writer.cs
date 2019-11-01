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
        private StreamWriter _sw;
        public Writer(string path)
        {
            _sw = File.CreateText(path);
            _sw.Close();
        }
        public void WriteFile(List<ITrack> list)
        {
            string path = "log.txt";
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");
            
            _sw = new StreamWriter(path);
            foreach (ITrack track in list)
            {
                var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);
                _sw.WriteLineAsync($"{track.Tag}\t" +
                             $"[{track.xCoordinate}:{track.yCoordinate}]\t" +
                             $"[{track.Altitude}]\t" +
                             $"[{timestamp}]\t");
            }
            _sw.Close();
        }

        public void WriteConsole(List<ITrack> list)
        {
            const string dateFormat = "yyyyMMddHHmmssfff";
            CultureInfo cultureInfo = new CultureInfo("da-DK");

            Console.Clear();
            foreach (ITrack track in list)
            {
                var timestamp = DateTime.ParseExact(track.TimeStamp, dateFormat, cultureInfo);
                Console.WriteLine($"{track.Tag}\t" +
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

            Console.WriteLine("Seperation: Tag1: {0}, Tag2: {1}, Timestamp1: {2}, Timestamp2: {3}", list[0].Tag, list[1].Tag,
                timestamp1, timestamp2);
        }

    }
}
