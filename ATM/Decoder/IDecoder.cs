using System;
using System.Collections.Generic;
using TransponderReceiver; 

namespace ATM_1
{
    public interface IDecoder
    {
        void DecodeEventHandler(object sender, RawTransponderDataEventArgs e);
        event EventHandler<DecoderEventArgs> DecodeEvent;
        List<string> Decode(string msg);
    }
}
