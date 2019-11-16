using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ATM_1
{
    public class FlightObject : IObjStruct
    {
        private List<ITrack> _objects;
        IVali _vali;
        readonly CultureInfo _cultureInfo = new CultureInfo("da-DK");
        const string DateFormat = "yyyyMMddHHmmssfff";

        public FlightObject(IVali vali)
        {
            _objects = new List<ITrack>();
            _vali    = vali;
        }

        public void Attach(ITrack flightTrack)
        {
            if(_vali.Validate(flightTrack))
            {
                if(CheckExist(flightTrack.Tag))
                {
                    //_objects.RemoveAll(item => item.Tag == flightTrack.Tag);
                    flightTrack = CalculateSpeed(flightTrack);
                }
                
                _objects.Add(flightTrack);
            }
            else if(CheckExist(flightTrack.Tag))
                _objects.RemoveAll(item => item.Tag == flightTrack.Tag);
        }

        public ITrack CalculateSpeed(ITrack newTrack)
        {
            var oldTrack = _objects.FirstOrDefault(o => o.Tag == newTrack.Tag);
            
            if (oldTrack == null) return newTrack;

            var xChange = newTrack.xCoordinate - oldTrack.xCoordinate;
            var yChange = newTrack.yCoordinate - oldTrack.yCoordinate;

                DateTime timeOld = DateTime.ParseExact(oldTrack.TimeStamp, DateFormat, _cultureInfo);
            DateTime timeNew = DateTime.ParseExact(newTrack.TimeStamp, DateFormat, _cultureInfo);

            var time = (timeNew - timeOld).TotalSeconds;
            
            
            var distance = Math.Sqrt(Math.Pow(xChange, 2) + Math.Pow(yChange, 2));
            double CompassDegree = ((Math.Atan2(yChange, xChange) * (180 / Math.PI)) - 90);
            
            //(CompassDegree < 0) ? CompassDegree = CompassDegree + 360 : CompassDegree;
            if (CompassDegree < 0)
                CompassDegree += 360;

            double Velocity = (time == 0.00) ? throw new DivideByZeroException("Time is zero") : ( (time < 0) ? throw new Exception("Time is negative") : distance / time);

            newTrack.HorizontalVelocity = Math.Round(Velocity, 2);
            newTrack.CompassCourse = Math.Round(CompassDegree, 2);

            _objects.RemoveAll(item => item.Tag == oldTrack.Tag);

            return newTrack;
        }

        public void clearList()
        {
            
                _objects.Clear();
            }

        public void Detach(ITrack flightTrack)
        {
            _objects.Remove(flightTrack);
        }

        public bool CheckExist(string newTag)
        {
            //_objects.Find(x => x.Tag.Contains(flightTrack.Tag));
            foreach (ITrack e in _objects)
            {
               if(e.Tag == newTag)
                   return true;
            }
            return false;
        }

        public List<ITrack> getlist()
        {
            return _objects;
        }
    }
}
