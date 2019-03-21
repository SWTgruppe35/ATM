using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleRendering : IRender
    {
        public List<Plane> CopyPlaneList { get; set; }

        public ConsoleRendering(IMonitor Im)
        {
            Im.SeperationListReady += HandleSeperationListReady;
        }

        public void HandleSeperationListReady(object src, SeperationCalculatedEventArgs args)
        {
            CopyPlaneList= new List<Plane>(args.PlaneList);

            PrintPlanes(CopyPlaneList);
        }

        public bool Seperation;
        public bool Collision(bool SeperationCondition, Plane plane)
        {
            if (SeperationCondition == false)
            {
                Seperation = false;
                return Seperation;
            }
            else
            {
                Seperation = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DANGER!!!!!!! HOLY SHIT POSSIBLE COLLISION A HEAD, PLEASE BE AWARE! Concerning plane: " + plane.Tag);
                Console.ResetColor();
                return Seperation;
            }
        }
        public void PrintPlanes(List<Plane> planes)
        {
            Console.Clear();
            foreach (var plane in planes)
            {
                Console.WriteLine($"Plane with the following properties Tag:{plane.Tag} \t PositionX: {plane.PositionX} \t " +
                                  $"PositionY: {plane.PositionY} \t Altitude: {plane.Altitude} \t TimeStamp: {plane.Timestamp} \t HorizontalVel: {plane.HorizontalVelocity}" +
                                  $"\t CompassCourse: {plane.CompassCourse} ");
                Console.WriteLine("Awaiting new plane...");

                Collision(Seperation, plane);
                


            }
            
        }

        

    
    }
}
