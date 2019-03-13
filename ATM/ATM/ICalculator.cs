using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    interface ICalculator
    {
        List<Plane> ComparePlanes(List<Plane>);
        void CalculateVelocity(Plane, Plane);
        void CalculateCourse(Plane, Plane);
    }
}
