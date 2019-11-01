using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_1;

namespace AMT.Test.Unit.Seperation
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

    }
}
