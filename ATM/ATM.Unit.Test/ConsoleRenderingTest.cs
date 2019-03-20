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
        private IRender _uut;
        private Plane _Plane1;
        private List<Plane> _planeList;


        [SetUp]

        public void Setup()
        {
            _uut = new ConsoleRendering();
        }
        [Test]
        public void Printplanescheckprint()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));
            _planeList = new List<Plane>();
            _planeList.Add(_Plane1);

            var counter = 0;
            _uut = Substitute.For<ConsoleRendering>();
            _uut.When(x => x.PrintPlanes(ref _planeList)).Do(x => counter++);
     
            _uut.PrintPlanes(ref _planeList);
            _uut.PrintPlanes(ref _planeList);
            Assert.AreEqual(0, counter);
        }
        
        
    }
}
