using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;

namespace ATM.Unit.Test
{
    [TestFixture]
    class AirSpaceMonitorTest
    {
        private IPlaneTracker Ipt = Substitute.For<IPlaneTracker>();
        private AirSpaceMonitor _uut;
        private PlaneListReadyEventArgs planeList;
        private int _MonitorListReadyEventRaised;


        [SetUp]
        public void Setup()
        {
            _uut = new AirSpaceMonitor(Ipt);
            planeList = new PlaneListReadyEventArgs();
            planeList.PlaneList = new List<Plane>();

            for (var i = 0; i < 5; i++)
            {
                planeList.PlaneList.Add(new Plane("Plane" + i.ToString(), 50000, 50000, 5000, DateTime.Now));
            }

            //Event raised test
            _uut.MonitorListReady += (sender, args) => { ++_MonitorListReadyEventRaised; };

        }

        [TestCase(false, 499)]
        [TestCase(false, 20001)]
        [TestCase(true, 500)]
        [TestCase(true, 20000)]
        public void AltitudeBoundaries(bool inList, double altitude)
        {
            
            
            Plane testPlane = new Plane("testPlane", 50000, 50000, altitude, DateTime.Now);
            planeList.PlaneList.Add(testPlane);

            Ipt.PlaneListReady += Raise.EventWith(this, planeList);

           

            Assert.AreEqual(inList, planeList.PlaneList.Contains(testPlane));
        }

        [TestCase(false, 80001)]
        [TestCase(true, 80000)]
        public void PositionXBoundaries(bool inList, double posX)
        {
            Plane testPlane = new Plane("testPlane", posX, 50000, 500, DateTime.Now);
            planeList.PlaneList.Add(testPlane);

            Ipt.PlaneListReady += Raise.EventWith(this, planeList);

            Assert.AreEqual(inList, planeList.PlaneList.Contains(testPlane));
        }

        [TestCase(false, 80001)]
        [TestCase(true, 80000)]
        public void PositionYBoundaries(bool inList, double posY)
        {
            Plane testPlane = new Plane("testPlane", 50000, posY, 500, DateTime.Now);
            planeList.PlaneList.Add(testPlane);

            Ipt.PlaneListReady += Raise.EventWith(this, planeList);

            Assert.AreEqual(inList, planeList.PlaneList.Contains(testPlane));
        }

        [Test]
        public void MonitorListReadyEventInvoked()
        {
            _MonitorListReadyEventRaised = 0;

            Ipt.PlaneListReady += Raise.EventWith(this, planeList);

            Assert.AreEqual(1,_MonitorListReadyEventRaised);
        }

    }
}
