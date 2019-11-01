using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

using NSubstitute;
using NUnit.Framework;
using ATM_1;
using TransponderReceiver;

namespace AMT.Test.Unit
{
    [TestFixture]
    public class DecoderTest
    {
        //private IDecoder _uut;
        private Decoder _uut;
        private IObjStruct _ObjStruct;
        private ITransponderReceiver _receiver;

        private bool _eventHandled;
        private RawTransponderDataEventArgs _transponderDataEventArgs;

        [SetUp]
        public void Setup()
        {
            _eventHandled = false;

            _ObjStruct = Substitute.For<IObjStruct>();
            _receiver = Substitute.For<ITransponderReceiver>();

            _uut = new Decoder(_ObjStruct, _receiver);

            _receiver.TransponderDataReady += (sender, args) => _eventHandled = true;
            _receiver.TransponderDataReady += (sender, args) => _transponderDataEventArgs = args;
        }

        [Test]
        public void TransponderDataReadyEvent_DataReceived_EventHandled()
        {
            var data = new List<string>()
            {
                "ATR423;39045;12932;14000;20151006213456789",
                "ATR523;40045;13932;14000;20151006213456789",
                "ATR623;49045;14932;14000;20151006213456789"
            };

            _receiver.TransponderDataReady += Raise.EventWith(new RawTransponderDataEventArgs(data));
            Assert.That(_eventHandled, Is.True);
        }

        [Test]
        public void TransponderDataReadyEvent_DataReceived_StringsReceived()
        {
            var data = new List<string>()
            {
                "ATR423;39045;12932;14000;20151006213456789",
                "ATR523;40045;13932;14000;20151006213456789",
                "ATR623;49045;14932;14000;20151006213456789"
            };

            _receiver.TransponderDataReady += Raise.EventWith(new RawTransponderDataEventArgs(data));
            Assert.That(_transponderDataEventArgs.TransponderData, Is.EqualTo(data));
        }

        [Test]
        public void TransponderDataReadyEvent_DataReceived_ObjectStructureAdded()
        {
            var data = new List<string>()
            {
                "ATR423;39045;12932;14000;20151006213456789",
                "ATR523;40045;13932;14000;20151006213456789",
                "ATR623;49045;14932;14000;20151006213456789"
            };

            _receiver.TransponderDataReady += Raise.EventWith(new RawTransponderDataEventArgs(data));
            //Assert.That(_transponderDataEventArgs.TransponderData, Is.EqualTo(data));
            _ObjStruct.Received().Attach(Arg.Any<ITrack>());
        }

        [TestCase("ABC123", "1", "2", "3", "2019")]
        [TestCase("CDE456", "20", "30", "40", "201910")]
        public void DecodeData_DecodeString_DecodeSuccess(string tag, string xCoo, string yCoo, string altitude, string timeStamp)
        {
            var expectedResult = new List<string>() { tag, xCoo, yCoo, altitude, timeStamp };

            var data = string.Join(";", expectedResult);
            var transponderData = _uut.Decode(data);
            Assert.That(transponderData, Is.EqualTo(expectedResult));
        }
    }
}
