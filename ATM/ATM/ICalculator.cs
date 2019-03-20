using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{

    public interface ICalculator
    {
        event EventHandler<CalculatedListReadyEventArgs> CalculatedListReady;
    }

    public class CalculatedListReadyEventArgs : EventArgs
    {
        public List<Plane> PlaneList { get; set; }
    }

}
