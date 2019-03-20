using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class AirSpaceMonitor: IAirSpaceMonitor
   {
       public event EventHandler<MonitorListReadyEventArgs> MonitorListReady;

       public AirSpaceMonitor(IPlaneTracker ps)
       {
           ps.PlaneListReady += HandlePlaneListReady;
       }

       public void HandlePlaneListReady(object src, PlaneListReadyEventArgs planeList)
       {
           var copyPlaneList = new List<Plane>(planeList.PlaneList);

           var monitorList = new MonitorListReadyEventArgs {PlaneList = Monitor(copyPlaneList)};

           MonitorListReady?.Invoke(this, monitorList);
       }

        public List<Plane> Monitor( List<Plane> planes)
        {
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i].PositionX >80000 || planes[i].PositionY > 80000 || planes[i].Altitude < 500 || planes[i].Altitude > 20000)
                {
                    planes.RemoveAt(i);
                }
            }

            return planes;
        }
    }
}
