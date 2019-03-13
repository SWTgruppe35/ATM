using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    class Calculator : ICalculator
    {
        public List<Plane> FindPlanes(List<Plane> missing_name)
        {
            throw new NotImplementedException();
        }

        public void CalculateVelocity(Plane planeNew, Plane planeOld)
        {
            double x = PlaneNew.PositionX - PlaneOld.PositionX;

            if (x < 0)
                x = x * (-1);

            double y = PlaneNew.PositionY - PlaneOld.PositionY;

            if (y < 0)
                y = y * (-1);

            double time = PlaneOld.TimeStamp - PlaneNew.TimeStamp;

            PlaneNew.HorizontalVelocity = (Math.Sqrt((x * x) + (y * y)) / time);
        }

        public void CalculateCourse(Plane missing_name)
        {

        }

        private List<Plane> _planes;
    }
}
