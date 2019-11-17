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
        private IVali _uut;
        private IAirSpace _airSpace;

        [SetUp]
        public void Setup()
        {
            _airSpace = Substitute.For<IAirSpace>();
            _airSpace._LowerBoundary.Returns(500);
            _airSpace._UpperBoundary.Returns(20000);
            _airSpace._MaxX.Returns(80000);
            _airSpace._MaxY.Returns(80000);
            _uut = new Vali(_airSpace);
        }

        [TestCase("ATR423", "80000", "50000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "80000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "500", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20000", "2018051563055")]
        [TestCase("ATR423", "0", "0", "15000", "2018051563055")]
        public void ValidateTrackTest_Passed(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            //ITrack track = new ATM_1.Track("ATR423", "39405", "12932", "14000", "2018051563055");
            ITrack track = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);

            bool result = _uut.Validate(track);
            Assert.That(result, Is.True);
        }

        [TestCase("ATR423", "80001", "50000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "80001", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "499", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "499", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20001", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20001", "2018051563055")]
        public void ValidateTrackTest_Failed(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            ITrack track = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);

            bool result = _uut.Validate(track);
            Assert.That(result, Is.False);
        }
    }
}
