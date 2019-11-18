using System;
using NUnit.Framework;
using ATM_1;

namespace AMT.Test.Unit.Fakes
{
    [TestFixture]

    class FakeFlightObjTest
    {
        private IObjStruct _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new FakeFlightObj();
        }

        [Test]
        public void CalculateSpeed_NotImplemented_ExceptionIsThrown()
        {
            ITrack track = new ATM_1.Track("a", "1", "2", "3", "e");
            Assert.That(()=> _uut.CalculateSpeed(track), Throws.TypeOf<NotImplementedException>());
        }

        [Test]
        public void CheckExist_NotImplemented_ExceptionIsThrown()
        {
            Assert.That(() => _uut.CheckExist("Test"), Throws.TypeOf<NotImplementedException>());
        }

        [Test]
        public void ClearList_NotImplemented_ExceptionIsThrown()
        {
            Assert.That(()=> _uut.clearList(), Throws.TypeOf<NotImplementedException>());
        }

        [Test]
        public void Detach_NotImplemented_ExceptionIsThrown()
        {
            ITrack track = new ATM_1.Track("a","1","2","3","e");
            Assert.That(() => _uut.Detach(track), Throws.TypeOf<NotImplementedException>());
        }
    }
}
