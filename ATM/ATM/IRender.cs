using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IRender
    {
        void PrintPlanes(List<Plane> planes);

        bool Collision(bool SeperationCondition, Plane plane);



    }
}
