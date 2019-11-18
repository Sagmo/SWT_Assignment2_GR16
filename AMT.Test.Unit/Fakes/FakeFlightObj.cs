using System.Collections.Generic;
using ATM_1;

namespace AMT.Test.Unit.Fakes
{
    
    public class FakeFlightObj : IObjStruct
    {
        private List<ITrack> _objects;

        public FakeFlightObj()
        {
                _objects = new List<ITrack>();
        }

        public void Attach(ITrack track)
        {
            _objects.Add(track);
        }

        
        public List<ITrack> getlist()
        {
            return _objects;
        }

        public void Detach(ITrack flightTrack)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckExist(string newTag)
        {
            throw new System.NotImplementedException();
        }

        public ITrack CalculateSpeed(ITrack newTrack)
        {
            throw new System.NotImplementedException();
        }

        public void clearList()
        {
            throw new System.NotImplementedException();
        }
    }
}
