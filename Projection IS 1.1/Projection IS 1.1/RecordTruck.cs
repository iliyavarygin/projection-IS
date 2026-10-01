using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class RecordTruck: RecordCar
    {
        public double Weight { get; set; }
        public bool HaveDangareCargo { get; set; }

        public RecordTruck(DateTime date, string number, double weight, bool haveDangareCargo): base (date, number)
        {
            Weight = weight;
            HaveDangareCargo = haveDangareCargo;
        }
    }
}
