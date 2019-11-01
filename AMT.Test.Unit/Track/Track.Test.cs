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
        private Track uut;
        private string DummyTag = "ATR423";
        private string DummyYCord = "39405";
        private string DummyXCord = "12932";
        private string DummyAltitude = "14000";
        private string DummyDate = "2018051563055";
        [SetUp]
        public void Setup()
        {
            //uut = new Track();

        }

        [TestCase()]
        public void TestTrackTag()
        {

        }
    }
}
