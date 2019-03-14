using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class AirSpaceMonitor: IAirSpaceMonitor
    {

        private List<Plane> _planes = new List<Plane>();

        public void Monitor()
        {
            foreach (var plane in _planes)
            {
                if (plane.PositionX >80000 || plane.PositionY > 80000 || plane.Altitude < 500 || plane.Altitude > 20000)
                {
                    _planes.Remove(plane);
                }
            }
        }
    }
}
