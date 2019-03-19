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


        private IAirSpaceMonitor _uut;
        private List<Plane> _planes;


        [SetUp]
        public void Setup()
        {
            _uut = new AirSpaceMonitor();
            _planes = new List<Plane>();

            for (int i = 0; i < 5; i++)
            {
                _planes.Add(new Plane("Plane" + i.ToString(), 50000, 50000, 5000, DateTime.Now));
            }

        }

        [TestCase(false, 499)]
        [TestCase(false, 20001)]
        [TestCase(true, 500)]
        [TestCase(true, 20000)]
        public void AltitudeBoundaries(bool inList, double altitude)
        {
            Plane testPlane = new Plane("testPlane", 50000, 50000, altitude, DateTime.Now);
            _planes.Add(testPlane);

            _uut.Monitor(ref _planes);

            Assert.AreEqual(inList, _planes.Contains(testPlane));
        }

        [TestCase(false, 80001)]
        [TestCase(true, 80000)]
        public void PositionXBoundaries(bool inList, double posX)
        {
            Plane testPlane = new Plane("testPlane", posX, 50000, 500, DateTime.Now);
            _planes.Add(testPlane);

            _uut.Monitor(ref _planes);

            Assert.AreEqual(inList, _planes.Contains(testPlane));
        }

        [TestCase(false, 80001)]
        [TestCase(true, 80000)]
        public void PositionYBoundaries(bool inList, double posY)
        {
            Plane testPlane = new Plane("testPlane", 50000, posY, 500, DateTime.Now);
            _planes.Add(testPlane);

            _uut.Monitor(ref _planes);

            Assert.AreEqual(inList, _planes.Contains(testPlane));
        }


    }
}
