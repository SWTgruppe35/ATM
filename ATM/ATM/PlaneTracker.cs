using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM; 

namespace ATM
{
    public class PlaneTracker: IPlaneTracker
    {
        public event EventHandler<PlaneListReadyEventArgs> PlaneListReady;
        private ITransponderReceiver _receiver;
        private List<Plane> _planes = new List<Plane>();

        public PlaneTracker(ITransponderReceiver receiver)
        {
            _receiver = receiver;
            _receiver.TransponderDataReady += TransponderReceiverDataReady;
        }

        public List<Plane> Planes
        {
            get { return _planes; }
        }

        public Plane ConvertStringToPlane(String planeString)
        {
            // Eksempel: Transponderdata EIS771;5000;44789;6600;20190314094754096

            List<string> planeDataList = planeString.Split(';').ToList<string>();

            var plane = new Plane(
                            planeDataList[0],
                            double.Parse(planeDataList[1]),
                            double.Parse(planeDataList[2]),
                            double.Parse(planeDataList[3]),
                            ConvertStringToDatetime(planeDataList[4])
                            );
  
            return plane; 
        }

        public DateTime ConvertStringToDatetime(String dateString)
        {
            var format = "yyyyMMddHHmmssfff";

            var date = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

            return date;
        }


        private void TransponderReceiverDataReady(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.TransponderData)
            {
                _planes.Add(ConvertStringToPlane(data));
            }

            PlaneListReadyEventArgs args = new PlaneListReadyEventArgs();
            args.PlaneList = _planes;

            PlaneListReady?.Invoke(this, args);
            
        }
    }
}
