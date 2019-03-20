using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IPlaneTracker
    {
        event EventHandler<PlaneListReadyEventArgs> PlaneListReady; 
    }

    public class PlaneListReadyEventArgs : EventArgs
    {
        public List<Plane> PlaneList { get; set; }
    }

}
