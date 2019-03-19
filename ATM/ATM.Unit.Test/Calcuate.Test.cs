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
    public class ATMWithEventsUnitTests
    {
        private Calculator _uut;
        private List<Plane> _newPlane;
        private List<Plane> _oldPlane;
        private Plane _Plane1;
        private Plane _Plane2;




        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();

        }

        [Test]
        public void CalcuateFromOnePointEqualsZero()
        {
            _Plane1 = new Plane("tag1", 10000, 10000, 10000, DateTime.Now);

            _Plane2 = new Plane("tag2", 10000, 10000, 12000, DateTime.Now);

            _newPlane = new List<Plane>
            {
                _Plane1
            };

            _oldPlane = new List<Plane>
            {
                _Plane2
            };

            _uut.CalculateCourse(_Plane2, _Plane1);
            Assert.That(_Plane2.CompassCourse, Is.EqualTo(0));

        }   

    }
}


