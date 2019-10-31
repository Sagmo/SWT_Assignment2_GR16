using System;
using System.Collections.Generic;

namespace ATM_1
{
    public interface IObjStruct
    {
        public void Attach(ITrack flightTrack);
        //public void Update(ITrack flightTrack); // TODO remove this
        public void Detach(ITrack flightTrack);
        public bool CheckExist(string newTag);

        List<ITrack> getlist();

        //event EventHandler<ObjectEventArgs> ObjectEvent;
    }
}
