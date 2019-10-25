using System;
using System.Collections.Generic;
using System.Text;
using TransponderReceiver; 

namespace ATM_1
{
    public interface IDecoder
    {
    	void DecodeData(ITrack track, RawTransponderDataEventArgs e);
    }
}
