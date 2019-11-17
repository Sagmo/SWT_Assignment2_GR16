using System;
using System.Collections.Generic;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

namespace AMT.Test.Unit.ObjectStructureTest
{
    [TestFixture]
   	public class ObjectStructureTest
    {
        private IObjStruct _uut;
        private IVali _validator;

        [SetUp]
        public void Setup()
        {
            _validator = Substitute.For<IVali>();
            _validator.Validate(Arg.Any<ITrack>()).Returns(true);
            _uut = new FlightObject(_validator);
        }

        [Test] 
        public void SuccessfullyAttachTrack()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track);
            Assert.That(_uut.getlist()[0],Is.EqualTo(track));
        }

        [Test]
        public void SuccessfullyDetachTrack()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("th3", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track1);
            _uut.Attach(track2);
            _uut.Detach(track2);
            Assert.That(_uut.getlist(),Does.Not.Contain(track2));
            Assert.That(_uut.getlist(), Does.Contain(track1));
        }

        [Test]
        public void SuccessfullyGetList()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("th3", "6000", "5800", "10000", "20151006213456789");
            List<ITrack> list = new List<ITrack>() {track1, track2};
            _uut.Attach(track1);
            _uut.Attach(track2);
            Assert.That(_uut.getlist(), Is.EquivalentTo(list));
        }

        [Test]
        public void CheckExistTrue()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("th3", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track1);
            Assert.That(_uut.CheckExist(track1.Tag),Is.True);
            Assert.That(_uut.CheckExist(track2.Tag),Is.False);
        }

        [Test]
        public void AttachTrackWithTagThatAlreadyExists()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("thg", "7000", "5800", "10000", "20151006213456799");
            _uut.Attach(track1);
            _uut.Attach(track2);
            List<ITrack> list = new List<ITrack>(){track2};
            Assert.That(_uut.getlist(),Is.EquivalentTo(list));
        }

        [Test]
        public void AttachTrackWithTagThatAlreadyExists_TrackHasLeftAirspace_TrackRemovedFromList()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("thg", "7000", "5800", "30000", "20151006213456799");
            _uut.Attach(track1);
            _validator.Validate(Arg.Any<ITrack>()).Returns(false);
            _uut.Attach(track2);
            Assert.That(_uut.getlist().Contains(track2), Is.False);
        }

        [Test]
        public void ClearList_ResultsInEmptyList()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("th3", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track1);
            _uut.Attach(track2);

            _uut.clearList();

            Assert.That(_uut.getlist(),Is.Empty);
        }

        [Test]
        public void calculateSpeed_FirstOfTrackAdded_SpeedIs0()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track);
            Assert.That(_uut.getlist()[0].HorizontalVelocity, Is.EqualTo(0));
        }

        [Test] //Track with tag: thg, has moved 100m over a 1 second period. Expected speed to be 100 m/s.
        public void calculateSpeed_TrackWithUpdatedPos_SpeedIs100()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213457789");
            _uut.Attach(track);
            _uut.Attach(track1);
            Assert.That(_uut.getlist()[0].HorizontalVelocity, Is.EqualTo(100));
        }

        [Test] //Track with tag: thg has moved 100m in a 0 second period. Exception is thrown.
        public void calculateSpeed_100m_0seconds_ExceptionIsThrown()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213456789");
            _uut.Attach(track);
            Assert.That(() => _uut.Attach(track1), Throws.TypeOf<DivideByZeroException>());
        }

        [Test] //Track with tag: thg has moved 100m in a -1 second period. Exception is thrown.
        public void calculateSpeed_100m_NegativeSeconds_ExceptionIsThrown()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213455789");
            _uut.Attach(track);
            Assert.That(() => _uut.Attach(track1), Throws.Exception);
        }

        [Test]
        public void calculateSpeed_FirstOfTrackAdded_SpeedIs0_ExplicitTest()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            Assert.That(_uut.CalculateSpeed(track).HorizontalVelocity, Is.EqualTo(0));
        }

        [Test] //Track with tag: thg, has moved 100m over a 1 second period. Expected speed to be 100 m/s.
        public void calculateSpeed_TrackWithUpdatedPos_SpeedIs100_ExplicitTest()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213457789");
            _uut.Attach(track);
            Assert.That(_uut.CalculateSpeed(track1).HorizontalVelocity, Is.EqualTo(100));
        }

        [Test] //Track with tag: thg has moved 100m in a 0 second period. Exception is thrown.
        public void calculateSpeed_100m_0seconds_ExceptionIsThrown_ExplicitTest()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213456789");
            _uut.Attach(track);
            Assert.That(() => _uut.CalculateSpeed(track1), Throws.TypeOf<DivideByZeroException>());
        }

        [Test] //Track with tag: thg has moved 100m in a -1 second period. Exception is thrown.
        public void calculateSpeed_100m_NegativeSeconds_ExceptionIsThrown_ExplicitTest()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", "6100", "5800", "10000", "20151006213455789");
            _uut.Attach(track);
            Assert.That(() => _uut.CalculateSpeed(track1), Throws.Exception);
        }

        [Test]
        public void calculateSpeed_FirstTrackAdded_CompassCourseIs0()
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track);
            Assert.That(_uut.getlist()[0].CompassCourse, Is.EqualTo(0));
        }

        [Test]
        [TestCase("6000", "5900", 90)]
        [TestCase("6100", "5900", 45)]
        [TestCase("6250", "6000", 38.66)]
        [TestCase("5450", "6200", 143.97)]
        [TestCase("6050", "4500", 272.2)]
        [TestCase("6100","5800", 0)]
        [TestCase("63628", "32187", 24.6)]
        public void calculateSpeed_TrackWithUpdatedCompassCourse_CompassCourseIs45(string x, string y, double deg)
        {
            ITrack track = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track1 = new ATM_1.Track("thg", x, y, "10000", "20151006213457789");
            _uut.Attach(track);
            _uut.Attach(track1);
            Assert.That(_uut.getlist()[0].CompassCourse, Is.EqualTo(deg));
        }


    }
}
