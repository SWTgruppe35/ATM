using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public class Plane
    {
        public String Tag { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double Altitude { get; set; }

        public double Timestamp { get; set; }

        public double HorizontalVelocity { get; set; }

        public double CompassCourse { get; set; }

        public Plane(String tag, double positionX, double positionY, double altitude, double timestamp)
        {
            Tag = tag;
            PositionX = positionX;
            PositionY = positionY;
            Altitude = altitude;
            Timestamp = timestamp;
        }
    }
}
