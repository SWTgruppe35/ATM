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
            _plane1=new Plane("plane1", 50000, 20000, 18000, DateTime.Now);
            _plane2=new Plane("plane2", 50000, 20000, 18200, DateTime.Now);
            _plane3 = new Plane("plane3", 50000, 20000, 17800, DateTime.Now);
            _planes = new List<Plane>();
        }

        [Test]
        public void TwoConflictingPlanesCorrectNumberInConflictingPlanes()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);

            Assert.That(_uut._conflictingPlanes.Count, Is.EqualTo(2));
        }

        [Test]
        public void TwoConflictingPlanesCorrectPlane1InConflictingPlanes()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);


            Assert.Contains(_plane1, _uut._conflictingPlanes);
        }

        [Test]
        public void TwoConflictingPlanesCorrectPlane2InConflictingPlanes()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);


            Assert.Contains(_plane2, _uut._conflictingPlanes);
        }

        [Test]
        public void NoConflictingPlanes()
        {
            _planes.Add(_plane3);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);

            Assert.IsEmpty(_uut._conflictingPlanes);
        }

        [Test]
        public void ConflictingPlanesAreListedForEachPlaneTheyAreConflictingWith()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane3);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);


            Assert.That(_uut._conflictingPlanes.Count, Is.EqualTo(4));
        }

        [Test]
        public void NewConflictingPlanesOverwriteCount()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);
            List<Plane> _planeses = new List<Plane>();
            _planeses.Add(_plane1);
            _planeses.Add(_plane3);
            _uut.FindConflictingPlanes(_planeses);


            Assert.That(_uut._conflictingPlanes.Count, Is.EqualTo(2));
        }

        [Test]
        public void NewConflictingPlanesOverwritePlane1()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);
            List<Plane> _planeses = new List<Plane>();
            _planeses.Add(_plane1);
            _planeses.Add(_plane3);
            _uut.FindConflictingPlanes(_planeses);


            Assert.Contains(_plane1, _uut._conflictingPlanes);
        }

        [Test]
        public void NewConflictingPlanesOverwritePlane3()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);
            List<Plane> _planeses = new List<Plane>();
            _planeses.Add(_plane1);
            _planeses.Add(_plane3);
            _uut.FindConflictingPlanes(_planeses);


            Assert.Contains(_plane3, _uut._conflictingPlanes);
        }

        [Test]
        public void SameConflictingPlanesWillBeOverwritten()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);
            _uut.FindConflictingPlanes(_planes);

            Assert.That(_uut._conflictingPlanes.Count, Is.EqualTo(2));
        }

        [Test]
        public void SeparationConditionSetCorrect()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);

            Assert.That(_plane1.SeparationCondition, Is.EqualTo(true));
        }

        [Test]
        public void SeparationConditionFalseCorrect()
        {
            _planes.Add(_plane1);
            _planes.Add(_plane2);
            _uut.FindConflictingPlanes(_planes);
            List<Plane> _planeses = new List<Plane>();
            _planeses.Add(_plane1);
            _planeses.Add(_plane3);
            _uut.FindConflictingPlanes(_planeses);

            Assert.That(_plane2.SeparationCondition, Is.EqualTo(false));
        }


    }
}
