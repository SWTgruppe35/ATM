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
        event EventHandler<MonitorListReadyEventArgs> MonitorListReady;
    }

    public class MonitorListReadyEventArgs : EventArgs
    {
        public List<Plane> PlaneList { get; set; }
    }
}
