using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

namespace AMT.Test.Unit.Validation
{
    [TestFixture]
    class ValidationTest
    {
        private IVali _vali;
        private IAirSpace _airSpace;

        [SetUp]
        public void Setup()
        {
            _airSpace = Substitute.For<IAirSpace>();
            _airSpace._LowerBoundary.Returns(500);
            _airSpace._UpperBoundary.Returns(20000);
            _airSpace._X.Returns(80000);
            _airSpace._Y.Returns(80000);
            _vali = new Vali(_airSpace);
        }

        [Test]
        public void ValidateTrackTest_Passed()
        {
            ITrack track = new ATM_1.Track("ATR423", "39405", "12932", "14000", "2018051563055");
            bool result = _vali.Validate(track);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ValidateTrackTest_Failed()
        {
            ITrack track = new ATM_1.Track("ATR423", "39405", "12932", "250", "2018051563055");
            bool result = _vali.Validate(track);
            Assert.That(result, Is.False);
        }
    }
}
