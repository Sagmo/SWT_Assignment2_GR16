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
        private IAirSpace _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new AirSpace(10000,90000,10000,90000,500,20000);
        }

        [TestCase(70000, 90000, 70000, 90000, 500, 20000)]
        public void TestAirspaceConstructor(double minX, double maxX, double minY, double maxY, double lowerBoundary, double upperBoundary)
        {
            IAirSpace exceptionSpace = new AirSpace(minX, maxX, minY, maxY, lowerBoundary, upperBoundary);

            //Assert.Throws<Exception>(() => exceptionSpace);
            //Assert.That(() => exceptionSpace, Throws.TypeOf<Exception>());
        }

        [TestCase(90000)]
        public void TestAirspaceMaxX(double maxX)
        {
            Assert.That(_uut._MaxX,Is.EqualTo(maxX));
        }

        [TestCase(90000)]
        public void TestAirspaceMaxY(double maxY)
        {
            Assert.That(_uut._MaxX,Is.EqualTo(maxY));
        }

        [TestCase(10000)]
        public void TestAirspaceMinX(double minX)
        {
            Assert.That(_uut._MinX, Is.EqualTo(minX));
        }

        [TestCase(10000)]
        public void TestAirspaceMinY(double minY)
        {
            Assert.That(_uut._MinY, Is.EqualTo(minY));
        }

        [TestCase(500)]
        public void TestAirspaceGetLowerBoundary(double lowerBound)
        {
            Assert.That(_uut._LowerBoundary, Is.EqualTo(lowerBound));
        }

        [TestCase(20000)]
        public void TestAirspaceGetUpperBoundary(double upperBound)
        {
            Assert.That(_uut._UpperBoundary, Is.EqualTo(upperBound));
        }
    }
}
