using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TransponderReceiver;
using ATM;
using NSubstitute;

namespace ATM.Unit.Test
{
    [TestFixture]
    class PlaneTrackerTest
    {
        private ITransponderReceiver _receiver;
        private PlaneTracker _uut;
        private Plane _plane; 

        [SetUp]
        public void Setup()
        {
            _plane = Substitute.For<Plane>();
            _uut = new PlaneTracker(_receiver); 
        }

        // Eksempel: Transponderdata EIS771;5000;44789;6600;20190314094754096
        [Test]
        public void ATM_ConvertStringToDatetime_CorrectString()
        {
            DateTime date = new DateTime(2019, 3, 14, 9, 47, 54, 096);
            Assert.That(_uut.ConvertStringToDatetime("20190314094754096"), Is.EqualTo(date)); 
        }

    }
}
