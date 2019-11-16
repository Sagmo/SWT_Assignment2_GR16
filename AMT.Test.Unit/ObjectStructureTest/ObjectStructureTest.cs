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
        public void ClearList_ResultsInEmptyList()
        {
            ITrack track1 = new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789");
            ITrack track2 = new ATM_1.Track("th3", "6000", "5800", "10000", "20151006213456789");
            _uut.Attach(track1);
            _uut.Attach(track2);

            _uut.clearList();

            Assert.That(_uut.getlist(),Is.Empty);
        }
    }
}
