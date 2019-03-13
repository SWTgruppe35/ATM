﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    class Calculator : ICalculator
    {
        public List<Plane> ComparePlanes(List<Plane> newPlanes)
        {
            if (_planes.Count != 0)
            {
                foreach (var i in newPlanes)
                {
                    foreach (var j in _planes)
                    {
                        if (i.Tag == j.Tag)
                        {
                            CalculateVelocity(i,j);
                            CalculateCourse(j, i);
                        }
                    }
                }
            }
            _planes = newPlanes;
            return _planes;
        }

        public void CalculateVelocity(Plane planeNew, Plane planeOld)
        {
            double x = planeNew.PositionX - planeOld.PositionX;

            if (x < 0)
                x = x * (-1);

            double y = planeNew.PositionY - planeOld.PositionY;

            if (y < 0)
                y = y * (-1);

            double time = planeOld.Timestamp - planeNew.Timestamp;

            planeNew.HorizontalVelocity = (Math.Sqrt((x * x) + (y * y)) / time);
        }

        public void CalculateCourse(Plane planeOld, Plane planeNew)
        {
            double x = planeOld.PositionX - planeNew.PositionX;
            double y = planeNew.PositionY - planeOld.PositionY;
            double m = y / x;

            planeNew.CompassCourse = Math.Atan(m);
        }

        private List<Plane> _planes;
    }
}