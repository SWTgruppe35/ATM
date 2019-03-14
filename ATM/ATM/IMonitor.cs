using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IMonitor
    {
        void FindConflictingPlanes(List<Plane>);
        void LogPlane(Plane);

    }
}
