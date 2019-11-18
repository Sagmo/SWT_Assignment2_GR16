using System.Collections.Generic;
using AMT.Test.Unit.Fakes;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

namespace AMT.Test.Unit.LoggerTest
{
    [TestFixture]
    class LogTest
    {
        private ILog _uut;
        private IWriter _writer;
        private ISeperation _seperation;
        private IDecoder _decoder;
        private IObjStruct _iOjbStruct;

        private bool _decoderEventBool = false;
        private bool _seperationWarningBool = false;

        private DecoderEventArgs _decoderEventArgs;
        private SeperationWarningEventArgs _seperationWarningEventArgs;


        [SetUp]
        public void Setup()
        {
            _decoder = Substitute.For<IDecoder>();
            _seperation = Substitute.For<ISeperation>();
            _writer = Substitute.For<IWriter>();
            _iOjbStruct = new FakeFlightObj();

            _uut = new Log(_seperation, _writer, _decoder);

            _seperation.SeperationWarningEvent += (sender, args) => _seperationWarningBool = true;
            _seperation.SeperationWarningEvent += (sender, args) => _seperationWarningEventArgs = args;

            _decoder.DecodeEvent += (sender, args) => _decoderEventBool = true;
            _decoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
        }


        [Test]
        public void DecoderDecodeEvent_ListReceived_EventHandled()
        {
            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");
            
            _iOjbStruct.Attach(track1);
            _iOjbStruct.Attach(track2);

            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs {FlightObjectStruct = _iOjbStruct});
            Assert.That(_decoderEventBool, Is.True);
        }

        [Test]
        public void SeperationEvent_SeperationReceived_EventHandled()
        {
            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");

            var flightSepList = new List<ITrack>() {track1, track2};


            _seperation.SeperationWarningEvent += Raise.EventWith(new SeperationWarningEventArgs { SeperationList = flightSepList } );
            Assert.That(_seperationWarningBool, Is.True);
        }

        
        [Test]
        public void DecoderDecodeEvent_ListWritten_EventHandled()
        {
            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");

            _iOjbStruct.Attach(track1);
            _iOjbStruct.Attach(track2);

            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs { FlightObjectStruct = _iOjbStruct });

            Assert.That(_decoderEventArgs.FlightObjectStruct.getlist(), Is.EqualTo(_iOjbStruct.getlist()));
        }

        [Test]
        public void SeperationEvent_SeperationWritten_EventHandled()
        {
            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");

            var flightSepList = new List<ITrack>() { track1, track2 };

            _seperation.SeperationWarningEvent += Raise.EventWith(new SeperationWarningEventArgs { SeperationList = flightSepList });

            Assert.That(_seperationWarningEventArgs.SeperationList, Is.EqualTo(flightSepList));
        }
    }
}
 