using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class RecordCar
    {
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public RecordCar(DateTime date, string number)
        {
            Date = date.Date;
            Number = number;
        }
    }
}
