using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleRendering : IRender
    {
        public void PrintPlanes(ref List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                Console.WriteLine("Plane with the following properties");
                Console.WriteLine(plane.Tag);
                Console.WriteLine(plane.PositionX);
                Console.WriteLine(plane.PositionY);
                Console.WriteLine(plane.Altitude);
                Console.WriteLine(plane.HorizontalVelocity);
                Console.WriteLine(plane.CompassCourse);
                Console.WriteLine("Awaiting new plane...");
            }
        }

        public void PrintSpaceCollision(ref List<Plane> planes, bool setcollision)
        {
           
        }

    
    }
}
