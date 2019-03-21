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
       private IWriter writer;

        public List<Plane> CopyPlaneList { get; set; }

        public ConsoleRendering(IMonitor Im, IWriter wri)
        {
            writer = wri;
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
                writer.PrintWarningLine( "DANGER!!!!!!!HOLY SHIT POSSIBLE COLLISION A HEAD, PLEASE BE AWARE!Concerning plane: " +
                plane.Tag);
           
                return true;
            }
            else return false;
        }
        public void PrintPlanes(List<Plane> planes)
        {
            writer.ClearScreen();

            writer.PrintLine($"Number of planes in list: {planes.Count}");
            foreach (var plane in planes)
            {
               writer.PrintPlane(plane);

               Collision(plane);
            }
            
        }
        
    }
}
