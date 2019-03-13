using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface ICalculator
    {
        List<Plane> ComparePlanes(List<Plane> planes);
        void CalculateVelocity(Plane planeNew, Plane planeOld);
        void CalculateCourse(Plane planeOld, Plane planeNew);
    }
}
