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
            /*
            else if( _objects.Find(x => x.Tag.Contains(flightTrack.Tag)) != null ) 
            {
                 Detach(flightTrack);
            }
            */
        }

        public ITrack CalculateSpeed(ITrack newTrack)
        {
            var oldTrack = _objects.FirstOrDefault(o => o.Tag == newTrack.Tag);
            
            //if (flightTrack == null) return track;

            var posChange = new
            {
                xChange = newTrack.xCoordinate - oldTrack.xCoordinate,
                yChange = newTrack.yCoordinate - oldTrack.yCoordinate
            };

            
            var timeChange = new
            {
                timeOld = DateTime.ParseExact(oldTrack.TimeStamp, "yyyymmddhhmmssfff", new CultureInfo("dk-DK")),
                timeNew = DateTime.ParseExact(newTrack.TimeStamp, "yyyymmddhhmmssfff", new CultureInfo("dk-DK"))
            };

            var time = (timeChange.timeNew - timeChange.timeOld).TotalSeconds;
            
            
            var distance = Math.Sqrt(Math.Pow(posChange.xChange, 2) + Math.Pow(posChange.yChange, 2));
            double CompassDegree = ((Math.Atan2(posChange.yChange, posChange.xChange) * (180 / Math.PI)) - 90);
            
            //(CompassDegree < 0) ? CompassDegree = CompassDegree + 360 : CompassDegree;
            if (CompassDegree < 0)
                CompassDegree += 360;

            double Velocity;
            (time == 0.00) ? throw new DivideByZeroException("Time is zero") : ( (time < 0) ? throw new Exception("Time is negative") : Velocity = distance / time) );

            newTrack.HorizontalVelocity = Velocity;
            newTrack.CompassCourse = CompassDegree;

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
