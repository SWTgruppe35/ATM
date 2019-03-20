using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IRender
    {
        void PrintPlanes(ref List<Plane> planes);

        void PrintSpaceCollision(ref List<Plane> planes);


    }
}
