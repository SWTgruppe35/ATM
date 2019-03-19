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
            private  List<Plane> _planes;
            private Plane _plane;


       [SetUp]
            public void Setup()
            {
                _uut = new AirSpaceMonitor();
                _planes = new List<Plane>(); 
                _plane = new Plane("TestPlane",50000,50000,5000,DateTime.Now);
        }

            [Test]
            public void AltitudeOutOfBoundaries()
            {
                _plane.Altitude = 499;

                _planes.Add(_plane);

                _uut.Monitor(_planes);

                Assert.Contains( _plane, _planes);
            }

        
    }
}