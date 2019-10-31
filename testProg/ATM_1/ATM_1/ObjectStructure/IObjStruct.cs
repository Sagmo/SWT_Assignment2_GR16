using System;


namespace ATM_1
{
    public interface IObjStruct
    {
        public void Attach(ITrack flightTrack);
        public void Update(ITrack flightTrack);
        public void Detach(ITrack flightTrack);
        public bool CheckExist(string newTag);

        event EventHandler<ObjectEventArgs> ObjectEvent;
    }
}
