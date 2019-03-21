using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Writer:IWriter
    {
        public void PrintPlane(Plane plane)
        {
            Console.WriteLine($"Tag: {plane.Tag} \t X: {plane.PositionX} \t " +
                              $"Y: {plane.PositionY} \t Z: {plane.Altitude} \t Time: {plane.Timestamp} \t Vel: {plane.HorizontalVelocity:F2}" +
                              $"\t Course: {plane.CompassCourse:F2} ");
        }

        public void PrintWarningLine(String line)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(line);
            Console.ResetColor();
        }

        public void PrintLine(String str)
        {
            Console.WriteLine(str);
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

    }
}
