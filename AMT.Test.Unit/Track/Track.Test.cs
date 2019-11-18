using System;
using ATM_1;
using NUnit.Framework;

namespace AMT.Test.Unit.Track
{
    [TestFixture]
    public class TrackTest
    {
        private ITrack _uut;
        
        [SetUp]
        public void Setup()
        {
            //Empty Setup
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackTag(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.Tag, Is.EqualTo(tag));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackXCoo(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.xCoordinate, Is.EqualTo(Convert.ToDouble(xCoo)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackYCoo(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.yCoordinate, Is.EqualTo(Convert.ToDouble(yCoo)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackaptitude(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.Altitude, Is.EqualTo(Convert.ToDouble(aptitude)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTracktimestamp(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.TimeStamp, Is.EqualTo(timeStamp));
        }

        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 0, 0)]
        public void TestTrackHorizontalVelocity_Default(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double testHorVel, double testCompassCourse)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.HorizontalVelocity, Is.EqualTo(testHorVel));
        }

        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 50, 50)]
        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055", 100, 100)]
        public void TestTrackHorizontalVelocity(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double testHorVel, double testCompassCourse)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            _uut.HorizontalVelocity = testHorVel;

            Assert.That(_uut.HorizontalVelocity, Is.EqualTo(testHorVel));
        }


        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 0, 0)]
        public void TestTrackCompassCourse_Default(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double testHorVel, double testCompassCourse)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.CompassCourse, Is.EqualTo(testCompassCourse));
        }


        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 50, 50)]
        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055", 100, 100)]
        public void TestTrackCompassCourse(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double testHorVel, double testCompassCourse)
        {
            _uut = new ATM_1.Track(tag, xCoo, yCoo, aptitude, timeStamp);
            _uut.CompassCourse = testCompassCourse;

            Assert.That(_uut.CompassCourse, Is.EqualTo(testCompassCourse));
        }


    }
}
