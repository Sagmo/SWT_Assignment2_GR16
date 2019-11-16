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

        public void Detach(ITrack track) { }

        public bool CheckExist(string e)
        {
            return false;
        }
        public List<ITrack> getlist()
        {
            return _objects;
        }

        public void clearList() { }

    }
}
