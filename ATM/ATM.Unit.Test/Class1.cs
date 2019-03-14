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
        private ICalculator _uut;
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
            _Plane1.Tag = "TestTag";
            _Plane1.PositionX = 12000;
            _Plane1.PositionY = 12000;
            _Plane1.Timestamp = new DateTime(20190314101814704);

            _Plane2.Tag = "TestTag2";
            _Plane2.PositionX = 12000;
            _Plane2.PositionY = 12000;
            _Plane2.Timestamp = new DateTime(20190314101814704);

            _newPlane = new List<Plane>
            {
                _Plane1

            };

            _oldPlane = new List<Plane>
            {
                _Plane2
            };

            
        }   

    }
}
