using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class AirSpaceMonitor: IAirSpaceMonitor
   {
        public List<Plane> Monitor(List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                if (plane.PositionX >80000 || plane.PositionY > 80000 || plane.Altitude < 500 || plane.Altitude > 20000)
                {
                    planes.Remove(plane);
                }
            }

            return planes;
        }
    }
}
