using System;
using AMT.Test.Unit.Fakes;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

namespace AMT.Test.Unit.Seperation
{
    [TestFixture]
    public class SeperationTest
    {
        private ISeperation _uut;
        private IDecoder _decoder;
        private DecoderEventArgs _decoderEventArgs;
        private SeperationWarningEventArgs _seperationWarningEventArgs;
        private IObjStruct _objStruct;
        private bool _eventHandled;
        private bool _eventRaised;

        [SetUp]
        public void Setup()
        {
            _eventHandled = false;
            _eventRaised = false;
            _seperationWarningEventArgs = null;
            _decoder = Substitute.For<IDecoder>();
            _objStruct = new FakeFlightObj();
            _uut = new ATM_1.Seperation(_decoder);
            _decoder.DecodeEvent += (sender, args) => _eventHandled = true;
            _decoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
            _uut.SeperationWarningEvent += (sender, args) => _eventRaised = true;
            _uut.SeperationWarningEvent += (sender, args) => { _seperationWarningEventArgs = args; };
        }

        [Test]
        public void DecodeEvent_FlightIsAdded_EventIsHandled()
        {
            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");
            _objStruct.Attach(track1);
            _objStruct.Attach(track2);

            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs{FlightObjectStruct = _objStruct});
            Assert.That(_eventHandled, Is.True);
        }

        [Test]
        public void HandleDecodeEvent_FlightsReceived_ListOfFlightReceived()
        {
            _objStruct.Attach(new ATM_1.Track("1", "2", "3", "600", "5"));
            _objStruct.Attach(new ATM_1.Track("1", "2", "3", "600", "5"));
            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs { FlightObjectStruct = _objStruct });
            Assert.That(_decoderEventArgs.FlightObjectStruct, Is.EqualTo(_objStruct));
        }

        [Test]
        public void CheckForSeparation_FlightAreInSeparation_EventIsRaised()
        {
            _objStruct.Attach(new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _objStruct.Attach(new ATM_1.Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_objStruct.getlist());
            Assert.That(_seperationWarningEventArgs, Is.Not.Null);
        }

        [Test]
        public void CheckForSeparation_FlightAreInSeparation_ListsEquivalent()
        {
            _objStruct.Attach(new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _objStruct.Attach(new ATM_1.Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_objStruct.getlist());
            Assert.That(_seperationWarningEventArgs.SeperationList, Is.EquivalentTo(_objStruct.getlist()));
        }

        [Test]
        public void CheckForSeparation_FlightAreNotInSeparation_EventNotRaised()
        {
            _objStruct.Attach(new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _objStruct.Attach(new ATM_1.Track("abc", "12000", "14000", "13000", "20151006213456781"));

            _uut.CheckSeperation(_objStruct.getlist());
            Assert.That(_seperationWarningEventArgs, Is.Null);
        }

        [Test]
        public void CheckForSeparation_ArgumentListIsEmpty_ThrowException()
        {
            Assert.That(() => _uut.CheckSeperation(_objStruct.getlist()), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CheckForSeparation_ArgumentIsNull_ThrowException()
        {
            Assert.That(() => _uut.CheckSeperation(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        // TRUE = SEPERATION, FALSE = NO SEPERATION
        // TEST BOUNDARY VALUE FOR X, HEIGHT DIFF < 300
        [TestCase("CDE", "9582", "7000", "1100", "20151006213456789", true)]
        [TestCase("CDE", "9583", "7000", "1100", "20151006213456789", false)]
        // TEST BOUNDARY VALUE FOR Y, HEIGHT DIFF < 300
        [TestCase("CDE", "7000", "9582", "1100", "20151006213456789", true)]
        [TestCase("CDE", "7000", "9583", "1100", "20151006213456789", false)]
        // TEST SEPERATION VERTICAL (X), BOUNDARY ALTITUDE
        [TestCase("CDE", "9582", "7000", "1299", "20151006213456789", true)]
        [TestCase("CDE", "9582", "7000", "1300", "20151006213456789", false)]
        // TEST SEPERATION VERTICAL (Y), BOUNDARY ALTITUDE
        [TestCase("CDE", "7000", "9582", "1299", "20151006213456789", true)]
        [TestCase("CDE", "7000", "9582", "1300", "20151006213456789", false)]
        // TEST BOUNDARY VALUE FOR X, HEIGHT DIFF > 300
        [TestCase("CDE", "9582", "7000", "1500", "20151006213456789", false)]
        [TestCase("CDE", "9583", "7000", "1500", "20151006213456789", false)]
        // TEST BOUNDARY VALUE FOR Y, HEIGHT DIFF > 300
        [TestCase("CDE", "7000", "9582", "1500", "20151006213456789", false)]
        [TestCase("CDE", "7000", "9583", "1500", "20151006213456789", false)]
        // NO SEPERATION HORIZONTAL, SEPERATION ALTITUDE
        [TestCase("CDE", "7000", "10000", "1100", "20151006213456789", false)]
        [TestCase("CDE", "10000", "7000", "1100", "20151006213456789", false)]
        /*
         [TestCase("CDE", "11900", "7000", "9700", "20151006213456789", false)]
        [TestCase("CDE", "10899", "7000", "9699", "20151006213456789", false)]
        //[TestCase("CDE", "10898", "7000", "9701", "20151006213456789", true)]
        [TestCase("CDE", "0", "0", "0", "20151006213456789", false)]
        [TestCase("CDE", "0", "0", "700", "20151006213456789", false)]
        [TestCase("CDE", "0", "0", "1300", "20151006213456789", false)]
        [TestCase("CDE", "0", "5000", "1000", "20151006213456789", false)]
        [TestCase("CDE", "5000", "0", "1000", "20151006213456789", false)]
        [TestCase("CDE", "5000", "5000", "0", "20151006213456789", false)]
        [TestCase("CDE", "5000", "5000", "700", "20151006213456789", false)]
        [TestCase("CDE", "20000", "20000", "1000", "20151006213456789", false)]
        [TestCase("CDE", "10000", "10000", "1000", "20151006213456789", false)]
        [TestCase("CDE", "5000", "5000", "701", "20151006213456789", true)]
        [TestCase("CDE", "4999", "4999", "999", "20151006213456789", true)]
        [TestCase("CDE", "5001", "5001", "1001", "20151006213456789", true)]
        [TestCase("CDE", "5000", "5000", "1299", "20151006213456789", true)]
        [TestCase("CDE", "5000", "5000", "1000", "20151006213456789", true)]
        */
        public void CheckForSeparation_BVA_Test(string tag, string x, string y, string altitude, string time, bool eventRaised)
        {
            _objStruct.Attach(new ATM_1.Track("ABC", "5000", "5000", "1000", "20151006213456789"));
            _objStruct.Attach(new ATM_1.Track(tag, x, y, altitude, time));
            _uut.CheckSeperation(_objStruct.getlist());
            Assert.That(_eventRaised, Is.EqualTo(eventRaised));
        }

    }
}
