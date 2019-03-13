using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    class PlaneTracker
    {
        private ITransponderReceiver receiver;
        private List<Plane> _planes = new List<Plane>();

        public PlaneTracker()
        {

        }


        private Plane ConvertStringToPlane(String planeString)
        {

            return null; 
        }

        private void TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            
            foreach (var data in e.TransponderData)
            {
                _planes.Add(ConvertStringToPlane(data));
            }
        }


    }
}
