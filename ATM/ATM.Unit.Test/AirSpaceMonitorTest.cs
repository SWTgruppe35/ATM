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
            private  List<Plane> planes;


            [SetUp]
            public void Setup()
            {
                _uut = new AirSpaceMonitor();
                planes = new List<Plane>();
            }

            [Test]
            public void AltitudeOutOfBoundaries()
            {
                var sub = Substitute.For<Plane>();

                //sub.Altitude = 

                //_uut.Monitor(planes);
            }

        
    }
}
