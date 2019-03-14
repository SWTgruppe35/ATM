using System;
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
            foreach (var i in _conflictingPlanes)
            {
                foreach (var j in _conflictingPlanes)
                {
                    
                }
            }
        }

        public void CheckIfLogged(Plane plane)
        {
            foreach (var i in _conflictingPlanes)
            {
                if (i.Tag == plane.Tag)
                    return;
            }

            //somehow call logger to log plane
            //log.LogConflictingPlanes(plane);
        }

        private List<Plane> _conflictingPlanes;
    }
}
