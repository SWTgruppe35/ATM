﻿using System;
using System.Collections.Generic;
using System.IO;
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
        private ATM.ILogger _uut;
        private Plane _plane1;
        private Plane _plane2;

        [SetUp]

        public void Setup()
        {
            File.Delete(@"..\LogFile.txt");
            _uut=new Logger();
            _plane1 = new Plane("plane1", 50000, 20000, 18000, DateTime.Now);
            _plane2 = new Plane("plane2", 50000, 20000, 18000, DateTime.Now);

        }

        [Test]
        public void OnePlaneCorrectLogged()
        {
            _uut.LogConflictingPlanes(_plane1);

            Assert.That(System.IO.File.ReadAllText(@"..\LogFile.txt"), Is.EqualTo(_plane1.Tag + "\r\n"));
        }

        [Test]
        public void MultiplePlanesCorrectLogged()
        {
            _uut.LogConflictingPlanes(_plane1);
            _uut.LogConflictingPlanes(_plane2);


            Assert.That(System.IO.File.ReadAllText(@"..\LogFile.txt"), Is.EqualTo(_plane1.Tag + "\r\n"+_plane2.Tag + "\r\n"));
        }
    }
}
