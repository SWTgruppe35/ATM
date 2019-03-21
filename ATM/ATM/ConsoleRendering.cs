using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.Exceptions;

namespace ATM
{
    public class ConsoleRendering
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
        public bool Collision(Plane plane)
        {
            if (plane.SeparationCondition == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(
                    "DANGER!!!!!!! HOLY SHIT POSSIBLE COLLISION A HEAD, PLEASE BE AWARE! Concerning plane: " +
                    plane.Tag);
                Console.ResetColor();
                return true;
            }
            else return false;
        }
        public void PrintPlanes(List<Plane> planes)
        {
            Console.Clear();

            Console.Write($"Number of planes in list: {planes.Count} \n");
            foreach (var plane in planes)
            {
                Console.WriteLine($"Tag: {plane.Tag} \t X: {plane.PositionX} \t " +
                                  $"Y: {plane.PositionY} \t Z: {plane.Altitude} \t Time: {plane.Timestamp} \t Vel: {plane.HorizontalVelocity:F2}" +
                                  $"\t Course: {plane.CompassCourse:F2} ");
               Collision(plane);
            }
            
        }
        
    }
}
