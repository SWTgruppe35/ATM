using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Logger: ILogger
    {
        public void LogConflictingPlanes(Plane plane1)
        {
            string[] file = {plane1.Tag};
            System.IO.File.WriteAllLines(@"C:\Users\Tobias\source\repos\SWTgruppe35\ATM\ATM\LogFile.txt", file);
        }
    }
}
