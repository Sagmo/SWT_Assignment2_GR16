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

            IAirSpace _airSpace   = new AirSpace(10000, 90000, 10000, 90000, 500, 20000);
            IObjStruct _objStruct = new FlightObject(new Vali(_airSpace));
            IDecoder _decoder     = new Decoder(_objStruct, TransponderReceiverFactory.CreateTransponderDataReceiver());
            IWriter _writer = new Writer("log.txt");
            ISeperation _seperation = new Seperation(_decoder);
            Log _log = new Log(_seperation, _writer, _decoder);
            
            while (true)
            {
                
            }
        }
    }
}
