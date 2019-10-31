using System;
using System.Collections.Generic;

namespace ATM_1
{
    public interface IObjStruct
    {
        public void Attach(ITrack flightTrack);
        public void Detach(ITrack flightTrack);
        public bool CheckExist(string newTag);
<<<<<<< HEAD

        List<ITrack> getlist();

        //event EventHandler<ObjectEventArgs> ObjectEvent;
=======
>>>>>>> 93f916bc05a26092f41b32627ecd97c452178a33
    }
}
