using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class Plane
    {
        public String Tag { get; }

        public double PositionX { get; }

        public double PositionY { get;}

        public double Altitude { get; }

        public DateTime Timestamp { get; set; }

        public Plane(String tag, double positionX, double positionY, double altitude, DateTime timestamp)
        {
            Tag = tag;
            PositionX = positionX;
            PositionY = positionY;
            Altitude = altitude;
            Timestamp = timestamp;
        }
    }
}
