/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_1;
using NSubstitute;
using NUnit.Framework;

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
            _ilog = Substitute.For<ILog>();
        }

        [Test]
        public void test_writeFile()
        {

        }

        [Test]
        public void test_writeConsole()
        {
            List<ITrack> list = new List<ITrack>();

            ITrack track1 = new ATM_1.Track("1", "2", "3", "600", "5");
            ITrack track2 = new ATM_1.Track("1", "2", "3", "600", "5");

            list.Add(track1);
            list.Add(track2);

            
            //Assert.That(_uut.WriteConsole(list), );
        }
    }
}
*/