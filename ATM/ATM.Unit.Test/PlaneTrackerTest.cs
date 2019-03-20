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
        private ITransponderReceiver _fakeReceiver;
        private PlaneTracker _uut;
        private Plane _plane;
        private List<String> _planeStringlist;
        private DateTime _date;
        private int _listReadySignal;


        [SetUp]
        public void Setup()
        {
            _fakeReceiver = Substitute.For<ITransponderReceiver>();

            _date = new DateTime(2019, 3, 14, 9, 47, 54, 096);
            _plane = new Plane("EIS771", 5000.0, 44789.0, 6600.0, _date);
            _planeStringlist = new List<string>();

            _uut = new PlaneTracker(_fakeReceiver); 
        }

        // Eksempel: EIS771;5000;44789;6600;20190314094754096
        [Test]
        public void ATM_ConvertStringToDatetime_CorrectString()
        {
            Assert.That(_uut.ConvertStringToDatetime("20190314094754096"), Is.EqualTo(_date)); 
        }

        [Test]
        public void ATM_ConvertStringToPlane_CorrectString()
        { 
            Plane plane = _uut.ConvertStringToPlane("EIS771;5000;44789;6600;20190314094754096");
            // Can't compare two different planes so it will be done by properties
            Assert.That(_plane.Tag, Is.EqualTo(plane.Tag)); 
            Assert.That(_plane.PositionX, Is.EqualTo(plane.PositionX));
            Assert.That(_plane.PositionY, Is.EqualTo(plane.PositionY));
            Assert.That(_plane.Altitude, Is.EqualTo(plane.Altitude));
            Assert.That(_plane.Timestamp, Is.EqualTo(plane.Timestamp));
        }

        [Test]
        public void ATM_HandleEventOnNewTransponderData()
        {
            _planeStringlist.Add("EIS771;5000;44789;6600;20190314094754096");
            _planeStringlist.Add("EIS772;5000;44789;6600;20190314094754096");
            _planeStringlist.Add("EIS773;5000;44789;6600;20190314094754096");

            _fakeReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(_planeStringlist));

            Assert.That(_uut.Planes[0].Tag, Is.EqualTo(_plane.Tag));
            Assert.That(_uut.Planes[1].Tag, Is.EqualTo("EIS772"));
            Assert.That(_uut.Planes[2].Tag, Is.EqualTo("EIS773"));
        }

        [Test]
        public void ATM_RaiseEventOnPlaneListReady()
        {
            _listReadySignal = 0; 
            _uut.PlaneListReady += (sender, args) => { ++_listReadySignal; };

            _fakeReceiver.TransponderDataReady += Raise.EventWith(this, new RawTransponderDataEventArgs(_planeStringlist));

            Assert.That(_listReadySignal, Is.EqualTo(1));
        }
    }
}
