using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
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
        private IVali _vali;
        private IAirSpace _airSpace;

        private bool eventHandled = false;
        private bool eventRaised = false;
        [SetUp]
        public void Setup()
        {
            _seperationWarningEventArgs = null;
            //_vali = Substitute.For<IVali>();
            _airSpace = new AirSpace(80000,80000,500,20000);
            _vali = new Vali(_airSpace);
            _decoder = Substitute.For<IDecoder>();
            _opj = Substitute.For<IObjStruct>();
            _uut = new ATM_1.Seperation(_decoder);
            _decoder.DecodeEvent += (sender, args) => eventRaised = true;
            _decoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
            _uut.SeperationWarningEvent += (sender, args) => { _seperationWarningEventArgs = args; };
        }

        [Test]
        public void testtest()
        {
            _opj = new FlightObject(_vali);
            _opj.Attach(new Track("1","2","3","600","5"));
            _opj.Attach(new Track("1", "2", "3", "600", "5"));
            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs{FlightObjectStruct = _opj});
            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void hej()
        {
            _opj = new FlightObject(_vali);
            _opj.Attach(new Track("1", "2", "3", "600", "5"));
            _opj.Attach(new Track("1", "2", "3", "600", "5"));
            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs { FlightObjectStruct = _opj });
            Assert.That(_decoderEventArgs.FlightObjectStruct, Is.EqualTo(_opj));
        }

        [Test]
        public void hej2()
        {
            _opj = new FlightObject(_vali);
            _opj.Attach(new Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _opj.Attach(new Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_opj.getlist());
            Assert.That(_seperationWarningEventArgs, Is.Not.Null);
        }

        [Test]
        public void hej3()
        {
            _opj = new FlightObject(_vali);
            _opj.Attach(new Track("thg", "6000", "5800", "10000", "20151006213456789"));
            _opj.Attach(new Track("abc", "6000", "5800", "10000", "20151006213456781"));

            _uut.CheckSeperation(_opj.getlist());
            Assert.That(_seperationWarningEventArgs.SeperationList, Is.EquivalentTo(_opj.getlist()));
        }
    }
}
