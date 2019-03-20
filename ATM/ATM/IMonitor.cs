using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IMonitor
    {
        // event EventHandler<PlaneListCalculatedEventArgs> PlaneListReady;
    }

    public class PlaneListCalculatedEventArgs : EventArgs
    {
        public List<Plane> PlaneList { get; set; }
    }
}
