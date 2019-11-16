using System;
using System.Collections.Generic;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

namespace AMT.Test.Unit.Writer
{
    [TestFixture]
    public class WriterTest
    {
        private IWriter _uut;
        private int count = 0;
        [SetUp]
        public void Setup()
        {
            count += 1;
            //_uut = new ATM_1.Writer($"test{count}.txt"); // Need to make a whole new writer for each test, because Nunit & Resharper is stupid...
            _uut = new ATM_1.Writer("test.txt");
        }


        [Test]
        public void writeConsole_ArgumentIsNull_ThrowsException()
        {
            Assert.That(() => _uut.WriteConsole(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void writeConsole_ArgumentIsValidList_DoesNotThrow()
        {
            List<ITrack> list = new List<ITrack> { new ATM_1.Track("thg", "6000", "5800", "10000", "20151006213456789"), 
                new ATM_1.Track("ggg", "6000", "5800", "10000", "20151006213456789") };

            Assert.DoesNotThrow(() => _uut.WriteConsole(list));
        }


        [Test]
        public void writeConsole_ArgumentIsEmptyList_ThrowException()
        {
            List<ITrack> list = new List<ITrack>();

            Assert.That(() => _uut.WriteConsole(list), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void writeFile_ArgumentIsNull_ThrowsException()
        {
            Assert.That(() => _uut.WriteFile(null), Throws.TypeOf<NullReferenceException>());
        }

    }
}