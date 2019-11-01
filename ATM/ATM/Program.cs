using System;
using System.Collections.Generic;
using System.Threading;
using ATM_1;
using TransponderReceiver;

namespace ATM_1
{
    class Program
    {
        static void Main(string[] args)
        {

            IAirSpace _airSpace   = new AirSpace(80000, 80000, 500, 20000);
            IObjStruct _objStruct = new FlightObject(new Vali(_airSpace));
            IDecoder _decoder     = new Decoder(_objStruct, TransponderReceiverFactory.CreateTransponderDataReceiver());
            IWriter _writer = new Writer("log.txt");
            ISeperation _seperation = new Seperation(_decoder);
            Log _log = new Log(_seperation, _writer, _decoder);
            //ITrack track1 = new Track("1","2","3","4","5");
            //ITrack track2 = new Track("6", "7", "8", "9", "10");
            //List<ITrack> list = new List<ITrack>(){track2,track1};
            while (true)
            {
                //Thread.Sleep(500);
                //_writer.WriteFile(list);
            }
        }
    }
}
