using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ATM_1;
using TransponderReceiver;

namespace AMT.Test.Unit
{
    public class TrackTest
    {
        private Track _uut;
        
        [SetUp]
        public void Setup()
        {
            //uut = new Track();
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackTag(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.Tag, Is.EqualTo(tag));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackXCoo(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.xCoordinate, Is.EqualTo(Convert.ToDouble(xCoo)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackYCoo(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.yCoordinate, Is.EqualTo(Convert.ToDouble(yCoo)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTrackaptitude(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.Altitude, Is.EqualTo(Convert.ToDouble(aptitude)));
        }

        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055")]
        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055")]
        public void TestTracktimestamp(string tag, string xCoo, string yCoo, string aptitude, string timeStamp)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.TimeStamp, Is.EqualTo(timeStamp));
        }

        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 0, 0)]
        public void TestTrackHorizontalVelocity_Default(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double test_HorVel, double test_CompassCourse)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.HorizontalVelocity, Is.EqualTo(test_HorVel));
        }

        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 50, 50)]
        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055", 100, 100)]
        public void TestTrackHorizontalVelocity(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double test_HorVel, double test_CompassCourse)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            _uut.HorizontalVelocity = test_HorVel;

            Assert.That(_uut.HorizontalVelocity, Is.EqualTo(test_HorVel));
        }


        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 0, 0)]
        public void TestTrackCompassCourse_Default(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double test_HorVel, double test_CompassCourse)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            Assert.That(_uut.CompassCourse, Is.EqualTo(test_CompassCourse));
        }


        [TestCase("ATR500", "39405", "12932", "14000", "2018051563055", 50, 50)]
        [TestCase("ATR423", "39405", "12932", "14000", "2018051563055", 100, 100)]
        public void TestTrackCompassCourse(string tag, string xCoo, string yCoo, string aptitude, string timeStamp, double test_HorVel, double test_CompassCourse)
        {
            _uut = new Track(tag, xCoo, yCoo, aptitude, timeStamp);
            _uut.CompassCourse = test_CompassCourse;

            Assert.That(_uut.CompassCourse, Is.EqualTo(test_CompassCourse));
        }


    }
}
