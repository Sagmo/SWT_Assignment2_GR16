using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AMT.Test.Unit.Seperation
{
    [TestFixture]
    public class SeperationTest
    {
        private ATM_1.Seperation _uut;
        private IDecoder _decoder;
        private DecoderEventArgs _decoderEventArgs;
        private SeperationWarningEventArgs _seperationWarningEventArgs;
        private IObjStruct _opj;
        private bool _eventHandled = false;

        [SetUp]
        public void Setup()
        {
            _seperationWarningEventArgs = null;
            _decoder = Substitute.For<IDecoder>();
            _opj = new FakeFlightObj();
            _uut = new ATM_1.Seperation(_decoder);
            _decoder.DecodeEvent += (sender, args) => _eventHandled = true;
            _decoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
            _uut.SeperationWarningEvent += (sender, args) => { _seperationWarningEventArgs = args; };
        }

        [Test]
        public void DecodeEvent_FlightIsAdded_EventIsHandled()
        { ;
            ITrack track1 = new Track("1", "2", "3", "600", "5");
            ITrack track2 = new Track("1", "2", "3", "600", "5");
            _opj.Attach(track1);
            _opj.Attach(track2);

            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs{FlightObjectStruct = _opj});
            Assert.That(_eventHandled, Is.True);
        }

        [Test]
        public void HandleDecodeEvent_FlightsReceived_ListOfFlightReceived()
        {
            _opj.Attach(new Track("1", "2", "3", "600", "5"));
            _opj.Attach(new Track("1", "2", "3", "600", "5"));
            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs { FlightObjectStruct = _opj });
            Assert.That(_decoderEventArgs.FlightObjectStruct, Is.EqualTo(_opj));
        }

        [Test]
        public void CheckForSeparation_FlightAreInSeparation_EventIsRaised()
        {
            _opj.Attach(new Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _opj.Attach(new Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_opj.getlist());
            Assert.That(_seperationWarningEventArgs, Is.Not.Null);
        }

        [Test]
        public void CheckForSeparation_FlightAreInSeparation_ListsEquivalent()
        {
            _opj.Attach(new Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _opj.Attach(new Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_opj.getlist());
            Assert.That(_seperationWarningEventArgs.SeperationList, Is.EquivalentTo(_opj.getlist()));
        }
    }
}
