using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace ATM.Unit.Test
{
    [TestFixture]
    class LoggerTest
    {
        private ATM.ILogger _logger;
        private Plane _plane;

        [SetUp]

        public void Setup()
        {
            _logger=new Logger();
            _plane = new Plane("plane", 50000, 20000, 18000, DateTime.Now);
        }

        [Test]
        public void PlaneCorrectLogged()
        {
            _logger.LogConflictingPlanes(_plane);

            Assert.That(System.IO.File.ReadAllText(@"C:\Users\Tobias\source\repos\SWTgruppe35\ATM\ATM\LogFile.txt"), Is.EqualTo(_plane.Tag + "\r\n"));
        }
    }
}
