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

        private IMonitor Im = Substitute.For<IMonitor>();
        private SeperationCalculatedEventArgs seperationList;

        [SetUp]

        public void Setup()
        {
            _uut = new ConsoleRendering(Im);

            seperationList = new SeperationCalculatedEventArgs();
            seperationList.PlaneList = new List<Plane>();
        }

        [Test]
        public void Printplanescheckprint()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));
            _planeList = new List<Plane>();
            _planeList.Add(_Plane1);
            
            Assert.Contains(_Plane1, _planeList);
        }

        [Test]
        public void PrintCanReturnTrue()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));
            _uut.Collision(true, _Plane1);
            Assert.IsTrue(_uut.Seperation);
        }

        [Test]
        public void SeperationListReadyEventHandled()
        {

            for (int i = 0; i < 4; i++)
            {
                seperationList.PlaneList.Add(new Plane($"test{i}", 12000, 12000, 10000, DateTime.Now.AddSeconds(2)));

                if (i % 2 == 0)
                    seperationList.PlaneList[i].SeparationCondition = true;
            }

            Im.SeperationListReady += Raise.EventWith(this, seperationList);
        }


    }
    
}

    