using System;
using System.Transactions;
using ATM_1;
using NSubstitute;
using NUnit.Framework;
using TransponderReceiver;

namespace SkidMigIMundenPik
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
            public void JegErDUM()
            {
                Assert.AreEqual(1,1);
            }
        }
}
