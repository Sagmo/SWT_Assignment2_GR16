using System;
using System.Collections.Generic;
using System.Text;

using TransponderReceiver;

namespace ATM_1
{
    public class Decoder : IDecoder
    {
        private IObjStruct _flightObj;

        public event EventHandler<DecoderEventArgs> DecodeEvent;

        public Decoder(IObjStruct flightObj, ITransponderReceiver transRec)
        {
            _flightObj = flightObj;
            transRec.TransponderDataReady += DecodeEventHandler;
        }
        
        public void DecodeEventHandler(object sender, RawTransponderDataEventArgs e)
        {
            e.TransponderData.ForEach(rawData => 
            {
                var decodedDate = Decode(rawData);
                _flightObj.Attach(new Track(decodedDate[0], decodedDate[1], decodedDate[2], decodedDate[3], decodedDate[4]));
            });

           OnDecoderEvent(new DecoderEventArgs { FlightObjectStruct = _flightObj });
        }

        public List<string> Decode(string msg)
        {
            return new List<string>(msg.Split(';'));
        }

        // TODO Finishc emttyplist function, or remove this
        /*
        public void EmptyList(IObjStruct flightObj)
        {
            
        }
        */

        protected virtual void OnDecoderEvent(DecoderEventArgs e)
        {
            DecodeEvent?.Invoke(this, e);
        }
    }
}
