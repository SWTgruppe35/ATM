using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class ConsoleRenderingTest
    {
        private ConsoleRendering _uut;
        private Plane _Plane1;
        private List<Plane> _planeList;


        [SetUp]

        public void Setup()
        {
            _uut = new ConsoleRendering();
        }
        /*
        [Test]
        public void PrintAirplanes()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));
            _planeList = new List<Plane>();
            _planeList.Add(_Plane1);

            _uut.PrintPlanes(ref _planeList);

            Assert.That(_uut.PrintPlanes(ref _planeList), Has.);
        }
        */
    }
}
