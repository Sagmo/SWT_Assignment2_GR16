using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

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

        private bool eventHandled = false;
        private bool eventRaised = false;
        [SetUp]
        public void Setup()
        {
            _vali = Substitute.For<IVali>();
            _decoder = Substitute.For<IDecoder>();
            _opj = Substitute.For<IObjStruct>();
            _uut = new ATM_1.Seperation(_decoder);
            _decoder.DecodeEvent += (sender, args) => eventRaised = true;
            _decoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
            _uut.SeperationWarningEvent += (sender, args) => { eventRaised = true; };
        }

        [Test]
        public void testtest()
        {
            _opj = new FlightObject(_vali);
            _opj.Attach(new Track("1","2","3","4","5"));
            _opj.Attach(new Track("1", "2", "3", "4", "5"));
            _decoder.DecodeEvent += Raise.EventWith(new DecoderEventArgs{FlightObjectStruct = _opj});
            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void hej()
        {
            
        }


    }
}
