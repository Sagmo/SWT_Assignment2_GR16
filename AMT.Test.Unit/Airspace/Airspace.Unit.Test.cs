using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM_1;
using NUnit.Framework;


namespace AMT.Test.Unit.Airspace
{
    [TestFixture]
    public class AirspaceTest
    {
        private IAirSpace _airSpace;
        [SetUp]
        public void Setup()
        {
            _airSpace = new AirSpace(80000,80000,500,20000);
        }

        [Test]
        public void TestAirspaceGetX()
        {
            var x = _airSpace._X;
            Assert.That(_airSpace._X,Is.EqualTo(x));
        }

        [Test]
        public void TestAirspaceGetY()
        {
            var y = _airSpace._Y;
            Assert.That(_airSpace._Y,Is.EqualTo(y));
        }

        [Test]
        public void TestAirspaceGetLowerBoundary()
        {
            var lowerboundary = _airSpace._LowerBoundary;
            Assert.That(_airSpace._LowerBoundary, Is.EqualTo(lowerboundary));
        }

        [Test]
        public void TestAirspaceGetUpperBoundary()
        {
            var upperboundary = _airSpace._UpperBoundary;
            Assert.That(_airSpace._UpperBoundary, Is.EqualTo(upperboundary));
        }
    }
}
