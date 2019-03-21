using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class SeparationMonitor: IMonitor
    {
        public List<Plane> CopyPlaneList { get; set; }

        public event EventHandler<SeperationCalculatedEventArgs> SeperationListReady;

        public SeparationMonitor(ICalculator cal)
        {
            cal.CalculatedListReady += HandleCalculatedListReady;

            _conflictingPlanes=new List<Plane>();
            _logger=new Logger();
        }

        public void HandleCalculatedListReady(object src, CalculatedListReadyEventArgs args)
        {
            CopyPlaneList = new List<Plane>(args.PlaneList);

            FindConflictingPlanes(CopyPlaneList);

            var seperationList = new SeperationCalculatedEventArgs(){PlaneList = CopyPlaneList};

            SeperationListReady?.Invoke(this, seperationList);
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
                        planes[i].SeparationCondition = true;
                        planes[j].SeparationCondition = true;
                    }
                }
            }
            _conflictingPlanes = newPlanes;
        }

        public void LogPlane(Plane plane)
        {
            bool alreadyLogged=false;
            foreach (var i in _conflictingPlanes)
            {
                if (i.Tag == plane.Tag)
                    alreadyLogged = true;
            }

            if (alreadyLogged == false)
            {
                _logger.LogConflictingPlanes(plane);
            }
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
        private ILogger _logger;
    }
}
