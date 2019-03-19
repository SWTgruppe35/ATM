using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    public interface IAirSpaceMonitor
    {
        List<Plane> Monitor(ref List<Plane> planes);
    }
}
