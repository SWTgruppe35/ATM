using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    class SeparationMonitorTest
    {
        private List<Plane> _planes;
        private Plane _plane1;
        private Plane _plane2;
        private Plane _plane3;
        private SeparationMonitor _uut;
        [SetUp]
        public void Setup()
        {
            _uut=new SeparationMonitor();
            _plane1=new Plane("plane1", 50000, 18000, 18000, DateTime.Now);
            _plane2=new Plane("plane2", 52000, 20000, 18200, DateTime.Now);
            _plane3 = new Plane("plane3", 48000, 2200, 17800, DateTime.Now);
            _planes = new List<Plane>();
        }

        public void TwoConflictingPlanesCorrectInConflictingPlanes()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);

            Assert.That(_uut._conflictingPlanes.Count, Is.EqualTo(2));
        }
    }
}
