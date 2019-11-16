using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AMT.Test.Unit.Writer
{
    [TestFixture]
    public class WriterTest
    {
        private ATM_1.ILog _ilog;
        private ATM_1.IWriter _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new ATM_1.Writer("test.txt");
        }

        [Test]
        public void test_writeFile()
        {

        }

        [Test]
        public void test_writeConsole()
        {
            Assert.That(() => _uut.WriteConsole(null), Throws.Exception);
        }

        [Test]
        public void tetst()
        {
            List<ITrack> list = new List<ITrack> { new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789") };
            Assert.DoesNotThrow(() => _uut.WriteConsole(list));
        }


    }
}