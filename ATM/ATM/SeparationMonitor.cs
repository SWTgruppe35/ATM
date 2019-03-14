﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class SeparationMonitor: IMonitor
    {
        public void FindConflictingPlanes(List<Plane> planes)
        {
            List<Plane> newPlanes=new List<Plane>();
            for (int i=0; i<planes.Count;i++)
            {
                for (int j=i+1; j < planes.Count; j++)
                {
                    if (CheckConflictingPlanes(planes[i], planes[j]))
                    {
                        newPlanes.Add(planes[i]);
                        LogPlane(planes[i]);
                    }
                }
            }

            _conflictingPlanes = newPlanes;

            //somehow call render with new conflicting planes to render
        }

        public void LogPlane(Plane plane)
        {
            foreach (var i in _conflictingPlanes)
            {
                if (i.Tag == plane.Tag)
                    return;
            }

            //somehow call logger to log plane
            //log.LogConflictingPlanes(plane);
        }

        public bool CheckConflictingPlanes(Plane plane1, Plane plane2)
        {
            double x = plane1.PositionX - plane2.PositionX;

            if (x < 0)
                x = x * (-1);

            double y = plane1.PositionY - plane2.PositionY;

            if (y < 0)
                y = y * (-1);

            double distanceHorizontal = Math.Sqrt((x * x) + (y * y));
            double distanceVertical = plane1.Altitude - plane2.Altitude;
            if (distanceVertical < 0)
                distanceVertical = distanceVertical * (-1);
            if (distanceHorizontal < 5000 && distanceVertical < 300)
                return true;
            else
                return false;
        }

        private List<Plane> _conflictingPlanes;
    }
}
