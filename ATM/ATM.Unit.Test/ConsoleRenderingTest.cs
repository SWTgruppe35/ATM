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
    // Check if Prints in ConsoleRendering works and can run.
    [TestFixture]
    public class ConsoleRenderingTest
    {
        private Plane _Plane1;
        private List<Plane> _planeList;

        public void checkprint()
        {
            _Plane1 = new Plane("tag1", 12000, 12000, 10000, DateTime.Now.AddSeconds(2));
            _planeList = new List<Plane>();
            _planeList.Add(_Plane1);

            var counter = 0;
            var print = Substitute.For<IRender>();
            print.When(x => x.PrintPlanes(ref _planeList)).Do(x => counter++);

            print.PrintPlanes(ref _planeList);
            print.PrintPlanes(ref _planeList);
            Assert.AreEqual(2, counter);
        }
    }
}
