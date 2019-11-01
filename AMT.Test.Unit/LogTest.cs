using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using AMT.Test.Unit.Seperation;
using NSubstitute;
using NUnit.Framework;
using ATM_1;
using Castle.Core.Smtp;
using TransponderReceiver;

namespace AMT.Test.Unit
{
    [TestFixture]
    class LogTest
    {
        private Log _uut;
        private IWriter _iwriter;
        private ISeperation _ispeeration;
        private IDecoder _idecoder;
        private IObjStruct _iOjbStruct;
        private ITrack _itrack;


        private bool _decoderEventBool = false;
        private bool _seperationWarningBool = false;

        private DecoderEventArgs _decoderEventArgs;
        private SeperationWarningEventArgs _seperationWarningEventArgs;


        [SetUp]
        public void Setup()
        {
            _idecoder = Substitute.For<IDecoder>();
            _ispeeration = Substitute.For<ISeperation>();

            _iwriter = Substitute.For<IWriter>();
            _itrack = Substitute.For<ITrack>();

            _iOjbStruct = new FakeFlightObj();

            _uut = new Log(_ispeeration, _iwriter, _idecoder);

            _ispeeration.SeperationWarningEvent += (sender, args) => _seperationWarningBool = true;
            _ispeeration.SeperationWarningEvent += (sender, args) => _seperationWarningEventArgs = args;

            _idecoder.DecodeEvent += (sender, args) => _decoderEventBool = true;
            _idecoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
        }


        [Test]
        public void DecoderDecodeEvent_ListReceived_EventHandled()
        {
            ITrack track1 = new Track("1", "2", "3", "600", "5");
            ITrack track2 = new Track("1", "2", "3", "600", "5");
            
            _iOjbStruct.Attach(track1);
            _iOjbStruct.Attach(track2);

            _idecoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs {FlightObjectStruct = _iOjbStruct});
            Assert.That(_decoderEventBool, Is.True);
        }

        [Test]
        public void SeperationEvent_SeperationReceived_EventHandled()
        {
            ITrack track1 = new Track("1", "2", "3", "600", "5");
            ITrack track2 = new Track("1", "2", "3", "600", "5");

            var flightSepList = new List<ITrack>() {track1, track2};


            _ispeeration.SeperationWarningEvent += Raise.EventWith(new SeperationWarningEventArgs { SeperationList = flightSepList } );
            Assert.That(_seperationWarningBool, Is.True);
        }

        /*
        [Test]
        public void DecoderDecodeEvent_ListWritten_EventHandled()
        {
            ITrack track1 = new Track("1", "2", "3", "600", "5");
            ITrack track2 = new Track("1", "2", "3", "600", "5");

            _iOjbStruct.Attach(track1);
            _iOjbStruct.Attach(track2);

            _idecoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs { FlightObjectStruct = _iOjbStruct });
            Assert.That(_iwriter.WriteConsole(_iOjbStruct), Is.EqualTo(_iOjbStruct.getlist()));
        }
        */


    }
}
 