using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IMonitor
    {
       event EventHandler<SeperationCalculatedEventArgs> SeperationListReady;
    }

    public class SeperationCalculatedEventArgs : EventArgs
    {
        public List<Plane> PlaneList { get; set; }
    }
}
