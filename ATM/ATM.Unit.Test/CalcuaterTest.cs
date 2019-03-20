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
    public class CalcuaterTest
    {
        private Calculator _uut;
        private List<Plane> _newPlane;
        private List<Plane> _oldPlane;
        private List<Plane> planes;
        private List<Plane> planes1;
        private Plane _Plane1;
        private Plane _Plane2;
        private Plane _Plane3;
        private Plane _Plane4;
        private Plane _Plane5;
        private Plane _Plane6;
        private Plane _Plane7;





        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();

        }

        [Test]
        public void CalcuateFromOnePointEqualsZero()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));

            _Plane2 = new Plane("tag2", 10000, 10000, 12000, DateTime.Now);

            _uut.CalculateCourse(_Plane2, _Plane1);
            Assert.That(_Plane2.CompassCourse, Is.EqualTo(0));


        }

        [Test]
        public void CaculateVelocityisEqualto()
        {
            var _date1 = new DateTime(2019, 8, 8, 2, 4, 55);
            var _date2 = new DateTime(2019, 8, 8, 2, 4, 54);


            _Plane1 = new Plane("tag1", 400, 400, 10000, _date1);

            _Plane2 = new Plane("tag2", 300, 300, 14000, _date2);

            _uut.CalculateVelocity(_Plane1, _Plane2);
            Assert.That(_Plane1.HorizontalVelocity, Is.InRange(140, 144));
        }

        [Test]
        public void TestComparePlanesList()
        {
            var newlist = new Calculator()._planes;
            _Plane1 = new Plane("plane1", 50000, 20000, 18000, DateTime.Now);
            _Plane2 = new Plane("plane2", 50000, 20000, 18200, DateTime.Now);
            _Plane3 = new Plane("plane1", 50000, 20000, 17800, DateTime.Now);
            planes = new List<Plane>();

            planes.Add(_Plane1);
            planes.Add(_Plane2);
            planes.Add(_Plane3);

            _uut.ComparePlanes(planes);
            Assert.That(_uut._planes.Contains(_Plane1));
        }

        [Test]
        public void TestComparePlanesListfull()
        {
            var newlist = new Calculator()._planes;
            _Plane1 = new Plane("plane1", 50000, 20000, 18000, DateTime.Now);
            _Plane2 = new Plane("plane2", 50000, 20000, 18200, DateTime.Now);
            _Plane3 = new Plane("plane1", 50000, 20000, 17800, DateTime.Now);
            planes = new List<Plane>();

            planes.Add(_Plane1);
            planes.Add(_Plane2);
            planes.Add(_Plane3);

            _uut.ComparePlanes(planes);

            _Plane4 = new Plane("plane4", 50000, 20000, 17800, DateTime.Now);
            _Plane5 = new Plane("plane2", 50000, 20000, 17800, DateTime.Now);
            planes1 = new List<Plane>();

            planes.Add(_Plane4);
            planes.Add(_Plane5);

            planes1.Add(_Plane1);
            planes1.Add(_Plane4);
            planes1.Add(_Plane5);


            _uut.ComparePlanes(planes1);



            Assert.That(_uut._planes.Contains(_Plane5));
        }

    }
}


