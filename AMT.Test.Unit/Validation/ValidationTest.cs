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
        
        // BOUNDARY VALUES
        [TestCase("ATR423", "90000", "10000", "20000", "2018051563055")]
        [TestCase("ATR423", "10000", "90000", "20000", "2018051563055")]
        [TestCase("ATR423", "90000", "10000", "500", "2018051563055")]
        [TestCase("ATR423", "10000", "90000", "500", "2018051563055")]
        [TestCase("ATR423", "10000", "10000", "500", "2018051563055")]
        [TestCase("ATR423", "90000", "90000", "20000", "2018051563055")]
        // MIDDLE VALUES
        [TestCase("ATR423", "90000", "50000", "10000", "2018051563055")]
        [TestCase("ATR423", "50000", "90000", "10000", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "500", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20000", "2018051563055")]
        [TestCase("ATR423", "12345", "67890", "1234", "2018051563055")]
        [TestCase("ATR423", "87654", "32109", "5678", "2018051563055")]
        public void ValidateTrackTest_Passed(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            //ITrack track = new ATM_1.Track("ATR423", "39405", "12932", "14000", "2018051563055");
            ITrack track = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);

            bool result = _uut.Validate(track);
            Assert.That(result, Is.True);
        }

        // BOUNDARY VALUES
        [TestCase("ATR423", "90001", "90000", "20000", "2018051563055")]
        [TestCase("ATR423", "90000", "90001", "20000", "2018051563055")]
        [TestCase("ATR423", "90001", "10000", "20000", "2018051563055")]
        [TestCase("ATR423", "10000", "90001", "20000", "2018051563055")]
        [TestCase("ATR423", "10000", "9999", "20000", "2018051563055")]
        [TestCase("ATR423", "9999", "10000", "20000", "2018051563055")]
        [TestCase("ATR423", "90000", "9999", "20000", "2018051563055")]
        [TestCase("ATR423", "9999", "90000", "20000", "2018051563055")]
        [TestCase("ATR423", "90001", "90000", "500", "2018051563055")]
        [TestCase("ATR423", "90000", "90001", "500", "2018051563055")]
        [TestCase("ATR423", "90001", "10000", "500", "2018051563055")]
        [TestCase("ATR423", "10000", "90001", "500", "2018051563055")]
        [TestCase("ATR423", "10000", "9999", "500", "2018051563055")]
        [TestCase("ATR423", "9999", "10000", "500", "2018051563055")]
        [TestCase("ATR423", "90000", "9999", "500", "2018051563055")]
        [TestCase("ATR423", "9999", "90000", "500", "2018051563055")]
        [TestCase("ATR423", "90000", "10000", "499", "2018051563055")]
        [TestCase("ATR423", "10000", "90000", "20001", "2018051563055")]
        [TestCase("ATR423", "10000", "10000", "499", "2018051563055")]
        [TestCase("ATR423", "90000", "90000", "20001", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "499", "2018051563055")]
        [TestCase("ATR423", "50000", "50000", "20001", "2018051563055")]
        public void ValidateTrackTest_Failed(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            ITrack track = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);

            bool result = _uut.Validate(track);
            Assert.That(result, Is.False);
        }
    }
}
