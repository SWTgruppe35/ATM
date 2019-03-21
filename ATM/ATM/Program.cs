using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM
{
    class Program
    {

        static void Main(string[] args)
        {
            var reciever= TransponderReceiverFactory.CreateTransponderDataReceiver(); 

            IPlaneTracker planeTracker = new PlaneTracker(reciever);

            IAirSpaceMonitor airSpaceMonitor = new AirSpaceMonitor(planeTracker);

            ICalculator calculator = new Calculator(airSpaceMonitor);

            IMonitor monitor = new SeparationMonitor(calculator);

            IWriter writer = new Writer();

            ConsoleRendering consoleRendering = new ConsoleRendering(monitor, writer);

            while (true)
            {
                
            }
        }








    }
}
