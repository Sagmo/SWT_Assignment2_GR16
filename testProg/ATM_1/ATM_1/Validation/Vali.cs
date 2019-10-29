using System;

namespace ATM_1
{
    public class Vali : IVali
    {
        IAirSpace _airSpace; 
        public Vali(IAirSpace airSpace)
        {
            _airSpace = airSpace;
        }


        public bool Validate(ITrack track)
        {
            // Compare
            return true;
        }
    }
}
