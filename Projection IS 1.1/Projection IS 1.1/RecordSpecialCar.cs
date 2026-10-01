using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class RecordSpecialCar: RecordCar
    {
        public string Mission {  get; set; }
        public int Priority { get; set; }
        public RecordSpecialCar(DateTime date, string number, string mission, int priority): base(date, number)
        {
            Mission = mission;
            Priority = priority;
        }
    }
}
