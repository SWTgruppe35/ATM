using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
   public interface IWriter
    {
        void PrintPlane(Plane plane);

        void PrintLine(String str);

        void PrintWarningLine(String line);

        void ClearScreen();
    }
}
