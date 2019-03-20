using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Logger: ILogger
    {
        public Logger()
        {
            //_file=new StreamWriter(@"..\LogFile.txt", true);
        }
        public void LogConflictingPlanes(Plane plane1)
        {
            _file = new StreamWriter(@"..\LogFile.txt", true);
            string text = plane1.Tag;
            _file.WriteLine(text);
            _file.Close();
        }

        private StreamWriter _file;
    }
}
