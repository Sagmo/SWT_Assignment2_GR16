using System;
using System.Collections.Generic;

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
                    Detach(flightTrack);
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
