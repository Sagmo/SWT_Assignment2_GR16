using System;
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


            Console.WriteLine("Hello World!");
        }
    }
}
