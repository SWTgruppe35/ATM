using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeparationMonitor: IMonitor
    {
        public SeparationMonitor()
        {
            _conflictingPlanes=new List<Plane>();
        }
        public void FindConflictingPlanes(List<Plane> planes)
        {
            List<Plane> newPlanes=new List<Plane>();
            for (int i=0; i<planes.Count;i++)

            {
                for (int j=i+1; j < planes.Count; j++)
                {

                    if (CheckIfConflict(planes[i], planes[j]))
                    {
                        newPlanes.Add(planes[i]);
                        newPlanes.Add(planes[j]);
                        LogPlane(planes[i]);
                        LogPlane(planes[j]);
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

        public bool CheckIfConflict(Plane plane1, Plane plane2)
        {
            double x = plane1.PositionX - plane2.PositionX;


            double y = plane1.PositionY - plane2.PositionY;


            double HorizontalD = Math.Sqrt((x * x) + (y * y));
            double VerticalD = plane1.Altitude - plane2.Altitude;
            if (VerticalD < 0)
                VerticalD = VerticalD * (-1);
            if (HorizontalD < 5000 && VerticalD < 300)
                return true;
            else
                return false;
        }

        public List<Plane> _conflictingPlanes;
    }
}
