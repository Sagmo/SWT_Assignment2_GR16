using System;
using System.Collections.Generic;

namespace ATM_1
{
    public interface IObjStruct
    {
        void Attach(ITrack flightTrack);
        void Detach(ITrack flightTrack);
        bool CheckExist(string newTag);

        void clearList();

        List<ITrack> getlist();

        //event EventHandler<ObjectEventArgs> ObjectEvent;
    }
}
