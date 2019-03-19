using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface IMonitor
    {
        void FindConflictingPlanes(List<Plane> plane);
        void LogPlane(Plane plane);
        bool CheckIfConflict(Plane plane1, Plane plane2);
    }
}
