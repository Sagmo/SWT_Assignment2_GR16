using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ATM_1;

namespace ATM_1
{
    public class Log
    {
        private IWriter writer;
        public Log(ISeperation seperation, IWriter writer, IDecoder decoder)
        {
            seperation.SeperationWarningEvent += HandleSeperationWarning;
            decoder.DecodeEvent += HandleDecodeEvent;
            this.writer = writer;
        }

        private void HandleDecodeEvent(object sender, DecoderEventArgs e)
        {
            writer.WriteConsole(e.FlightObjectStruct.getlist());
        }

        private void HandleSeperationWarning(object sender, SeperationWarningEventArgs e)
        {
            writer.WriteSeperationConsole(e.SeperationList);
            writer.WriteFile(e.SeperationList);
        }
    }
}
