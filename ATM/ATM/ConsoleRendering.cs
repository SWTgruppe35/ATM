﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleRendering : IRender
    {
        public bool Seperation;
        public bool Collision(bool SeperationCondition)
        {
            if (SeperationCondition == false)
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("DANGER!!!!!!! HOLY SHIT POSSIBLE COLLISION A HEAD, PLEASE BE AWARE! Concerning plane: " + plane.Tag);
                Console.ResetColor();
                return true;
            }
        }
        public void PrintPlanes(List<Plane> planes)
        {
            foreach (var plane in planes)
            {
                Console.WriteLine("Plane with the following properties");
                Console.WriteLine(plane.Tag);
                Console.WriteLine(plane.PositionX);
                Console.WriteLine(plane.PositionY);
                Console.WriteLine(plane.Altitude);
                Console.WriteLine(plane.Timestamp);
                Console.WriteLine(plane.HorizontalVelocity);
                Console.WriteLine(plane.CompassCourse);
                Console.WriteLine("Awaiting new plane...");

                Collision(Seperation);


            }
        }

        

    
    }
}
