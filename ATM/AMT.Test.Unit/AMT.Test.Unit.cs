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
        private IDecoder uut;
        [SetUp]
        public void Setup()
        {
            IObjStruct fakeObjStruct = Substitute.For<IObjStruct>();
            ITransponderReceiver fakeTransponderReceiver = Substitute.For<ITransponderReceiver>();
            uut = new Decoder(fakeObjStruct, fakeTransponderReceiver);

        }
        [Test]
        public void Test()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
