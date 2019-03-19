using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class AirSpaceMonitor: IAirSpaceMonitor
   {
        public List<Plane> Monitor(ref List<Plane> planes)
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
