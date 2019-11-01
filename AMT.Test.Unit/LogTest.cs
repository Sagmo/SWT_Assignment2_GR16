using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
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

            _uut = new Log(_ispeeration, _iwriter, _idecoder);

            _ispeeration.SeperationWarningEvent += (sender, args) => _seperationWarningBool = true;
            _ispeeration.SeperationWarningEvent += (sender, args) => _seperationWarningEventArgs = args;

            _idecoder.DecodeEvent += (sender, args) => _decoderEventBool = true;
            _idecoder.DecodeEvent += (sender, args) => _decoderEventArgs = args;
        }


        [Test]
        public void DecoderDecodeEvent_ListReceived_EventHandled()
        {
            //_idecoder.DecodeEvent += Raise.EventWith<>();
        }
    }
}
