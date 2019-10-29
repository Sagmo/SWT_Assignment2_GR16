using System;
using System.Collections.Generic;

namespace ATM_1
{
    class FlightObject : IObjStruct
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
                    Update(flightTrack);
                } 
                else
                {
                    _objects.Add(flightTrack);
                }
                // EVENT
            }
        }

        public void Update(ITrack flightTrack)
        {
            _objects.Find(x => x.Tag.Contains(flightTrack.Tag));
        }

        public void Detach(ITrack flightTrack)
        {
            _objects.Remove(flightTrack);
        }

        public bool CheckExist(string newTag)
        {
            // _objects.Find(x => x.Tag.Contains(newTag));
            
            foreach (ITrack e in _objects)
            {
               if(e.Tag == newTag)
                   return true;
            }

            return false;
        }

    }
}
