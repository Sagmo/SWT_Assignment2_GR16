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
            _airSpace._MaxX.Returns(90000);
            _airSpace._MaxY.Returns(90000);
			_airSpace._MinX.Returns(10000);
			_airSpace._MinY.Returns(10000);
            _uut = new Vali(_airSpace);
        }

        [TestCase("ATR423", "90000", "50000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "90000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "500", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20000", "2018051563055")]
        [TestCase("ATR423", "10000", "10000", "15000", "2018051563055")]
        public void ValidateTrackTest_Passed(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            //ITrack track = new ATM_1.Track("ATR423", "39405", "12932", "14000", "2018051563055");
            ITrack track = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);

            bool result = _uut.Validate(track);
            Assert.That(result, Is.True);
        }

        [TestCase("ATR423", "90001", "50000", "1000", "2018051563055")]
        [TestCase("ATR423", "50000", "90001", "1000", "2018051563055")]
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
