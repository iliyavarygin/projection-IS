using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class LineBuilder
    {
        public static string BuildLine(RecordCar record)
        {
            if (record is RecordTruck truck)
                return $"truck|{truck.Date:dd.MM.yyyy}|{truck.Number}|{truck.Weight}|{truck.HaveDangareCargo}";

            if (record is RecordSpecialCar special)
                return $"special|{special.Date:dd.MM.yyyy}|{special.Number}|{special.Mission}|{special.Priority}";

            return $"car|{record.Date:dd.MM.yyyy}|{record.Number}";
        }
        public static void AppendToFile(RecordCar record, string path)
        {
            File.AppendAllText(path, BuildLine(record) + "\n");
        }
    }
}
