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
        [TestCase(10000, 89999, 10000, 90000, 500, 20000)]
        [TestCase(10001, 90000, 10000, 90000, 500, 20000)]
        [TestCase(10000, 90000, 10001, 90000, 500, 20000)]
        [TestCase(10000, 90000, 10000, 89999, 500, 20000)]
        [TestCase(-10000, -90000, -10000, -90000, -500, -20000)]
        [TestCase(-10000, 90000, 10000, 90000, 500, 20000)]
        [TestCase(10000, -90000, 10000, 90000, 500, 20000)]
        [TestCase(10000, 90000, -10000, 90000, 500, 20000)]
        [TestCase(10000, 90000, 10000, -90000, 500, 20000)]
        [TestCase(10000, 90000, 10000, 90000, -500, 20000)]
        [TestCase(10000, 90000, 10000, 90000, 500, -20000)]
        [TestCase(10000, 90000, 10000, 90000, -500, -20000)]

        public void TestAirspaceConstructor_InputsNotValid_ExceptionIsThrown(double minX, double maxX, double minY, double maxY, double lowerBoundary, double upperBoundary)
        {
            Assert.That(() => new AirSpace(minX, maxX, minY, maxY, lowerBoundary, upperBoundary), Throws.Exception);
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
