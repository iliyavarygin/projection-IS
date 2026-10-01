using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class Printer
    {
        public static void PrintRecords (List<RecordCar> records)
        {
            foreach (RecordCar record in records)
            {
                PrintRecord(record);
            }
        }
        public static void PrintRecord (RecordCar record)
        {
            if (record is RecordTruck truck)
            {
                Console.WriteLine($"{truck.Date:dd.MM.yyyy} | грузовик {truck.Number}, вес {truck.Weight} т, опасный груз: {truck.HaveDangareCargo}");
            }
            else if (record is RecordSpecialCar special)
            {
                Console.WriteLine($"{special.Date:dd.MM.yyyy} | спецтранспорт {special.Number}, миссия: {special.Mission}, приоритет: {special.Priority}");
            }
            else
            {
                Console.WriteLine($"{record.Date:dd.MM.yyyy} | машина {record.Number}");
            }
        }
    }
}
