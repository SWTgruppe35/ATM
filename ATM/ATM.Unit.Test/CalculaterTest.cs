﻿using System;
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
    public class CalculaterTest
    {
        private Calculator _uut;
        private List<Plane> planes;
        private List<Plane> planes1;
        private Plane _Plane1;
        private Plane _Plane2;
        private Plane _Plane3;
        private Plane _Plane4;
        private Plane _Plane5;

        private IAirSpaceMonitor Iasm = Substitute.For<IAirSpaceMonitor>();
        private MonitorListReadyEventArgs monitorList;
        private int _CalculatedListReadyEventRaised;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator(Iasm);

            monitorList = new MonitorListReadyEventArgs(){PlaneList = new List<Plane>()};
        }

        [Test]
        public void CalcuateFromOnePointEqualsZero()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));

            _Plane2 = new Plane("tag1", 10000, 10000, 12000, DateTime.Now);

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
            _Plane1 = new Plane("plane1", 50000, 20000, 18000, DateTime.Now);
            _Plane2 = new Plane("plane2", 50000, 20000, 18200, DateTime.Now);
            _Plane3 = new Plane("plane1", 50000, 20000, 17800, DateTime.Now);
            planes = new List<Plane>();

            planes.Add(_Plane1);
            planes.Add(_Plane2);
            planes.Add(_Plane3);

            _uut.ComparePlanes(planes);
            Assert.That(_uut._planes.Contains(_Plane1));
            Assert.That(_uut._planes.Contains(_Plane2));
            Assert.That(_uut._planes.Contains(_Plane3));

        }

        [Test]
        public void TestComparePlanesListfull()
        {
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



            Assert.That(_uut._planes.Contains(_Plane1));
            Assert.That(_uut._planes.Contains(_Plane4));
            Assert.That(_uut._planes.Contains(_Plane5));

        }

        [Test]
        public void TestComparePlanesListfullNumberOfPlanesInList()
        {
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



            Assert.That(_uut._planes.Count, Is.EqualTo(3));
        }

        [Test]
        public void TestCompareVelocity()
        {
            var _date1 = new DateTime(2019, 8, 8, 2, 4, 55);
            var _date2 = new DateTime(2019, 8, 8, 2, 4, 54);

            _Plane1 = new Plane("plane1", 3000, 2000, 18000, _date2);
            _Plane2 = new Plane("plane2", 3000, 2000, 18200, _date2);
            _Plane3 = new Plane("plane3", 3000, 2000, 17800, _date2);
            planes = new List<Plane>();

            planes.Add(_Plane1);
            planes.Add(_Plane2);
            planes.Add(_Plane3);

            _uut.ComparePlanes(planes);

            _Plane1 = new Plane("plane1", 1000, 2000, 18000, _date1);
            _Plane2 = new Plane("plane2", 1000, 2000, 18200, _date1);
            _Plane3 = new Plane("plane3", 1000, 2000, 17800, _date1);

            List<Plane> planes2=new List<Plane>();
            planes2.Add(_Plane1);
            planes2.Add(_Plane2);
            planes2.Add(_Plane3);

            _uut.ComparePlanes(planes2);

            Assert.That(_Plane1.HorizontalVelocity, Is.EqualTo(2000));
            Assert.That(_Plane2.HorizontalVelocity, Is.EqualTo(2000));
            Assert.That(_Plane3.HorizontalVelocity, Is.EqualTo(2000));


        }

        [Test]
        public void CalculatedListReadyInvoked()
        {
            _CalculatedListReadyEventRaised = 0;
            _uut.CalculatedListReady += (sender, args) => { ++_CalculatedListReadyEventRaised; };

            Iasm.MonitorListReady += Raise.EventWith(this, monitorList);

            Assert.AreEqual(1,_CalculatedListReadyEventRaised);
        }
    }
}


