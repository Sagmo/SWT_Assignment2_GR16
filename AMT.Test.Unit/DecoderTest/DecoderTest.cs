using System;
using System.Collections.Generic;
using AMT.Test.Unit.Fakes;
using ATM_1;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace AMT.Test.Unit.DecoderTest
{
    [TestFixture]
    public class DecoderTest
    {
        private IDecoder _uut;
        private IObjStruct _objStruct;
        private ITransponderReceiver _receiver;

        private bool _eventHandled;
        private RawTransponderDataEventArgs _transponderDataEventArgs;

        [SetUp]
        public void Setup()
        {
            _eventHandled = false;

            _objStruct = new FakeFlightObj();
            _receiver = Substitute.For<ITransponderReceiver>();

            _uut = new Decoder(_objStruct, _receiver);

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

        [TestCase("ATR423;39405;12932;14000;20151006213456789")]
        [TestCase("ATR523;40045;13932;14000;20151006213456789")]
        [TestCase("ATR623;49045;14932;14000;20151006213456789")]
        public void TransponderDataReadyEvent_DataReceived_ObjectStructureAdded(string input)
        {
            var data = new List<string>
            {
                input
            };

            var test = new List<string>(input.Split(';'));

            _receiver.TransponderDataReady += Raise.EventWith(new RawTransponderDataEventArgs(data));
            Assert.That(_objStruct.getlist().Find(x => x.Tag == test[0]).Tag, Is.EqualTo(test[0]));
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

        [Test]
        public void DecodeData_DecodeNull_ExceptionIsThrown()
        {
            Assert.That(()=> _uut.Decode(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void DecodeData_DecodeEmptyString_DecodeSuccess()
        {
            string data = "";
            Assert.That(() => _uut.Decode(data), Throws.Nothing);
        }
    }
}
