using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using ATM_1;

namespace ATM_1
{
    public class Log : ILog
    {
        private readonly IWriter _writer;
        public Log(ISeperation seperation, IWriter writer, IDecoder decoder)
        {
            seperation.SeperationWarningEvent += HandleSeperationWarning;
            decoder.DecodeEvent += HandleDecodeEvent;
            this._writer = writer;
        }

        private void HandleDecodeEvent(object sender, DecoderEventArgs e)
        {
            _writer.WriteConsole(e.FlightObjectStruct.getlist());
        }

        private void HandleSeperationWarning(object sender, SeperationWarningEventArgs e)
        {
            _writer.WriteSeperationConsole(e.SeperationList);
            _writer.WriteFile(e.SeperationList);
        }
    }
}
