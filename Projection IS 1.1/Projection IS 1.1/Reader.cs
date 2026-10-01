using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class Reader
    {
        public static RecordCar ReadRecord()
        {
            Console.Write("Тип (1 - машина, 2 - грузовик, 3 - спецтранспорт): ");
            string type = Console.ReadLine().Trim();
            if (type == "1") return ReadCar();
            if (type == "2") return ReadTruck();
            if (type == "3") return ReadSpecialCar();
            return null;
        }
        static RecordCar ReadCar()
        {
            DateTime date = ReadDate();
            string number = ReadNumber();
            return new RecordCar(date, number);
        }
        static RecordTruck ReadTruck()
        {
            DateTime date = ReadDate();
            string number = ReadNumber();
            double weight = ReadWeight();
            bool haveDangareCargo = ReadBool("Опасный груз (true/false): ");
            return new RecordTruck(date, number, weight, haveDangareCargo);
        }
        static RecordSpecialCar ReadSpecialCar()
        {
            DateTime date = ReadDate();
            string number = ReadNumber();
            string mission = ReadMission();
            int priority = ReadPriority();
            return new RecordSpecialCar(date, number, mission, priority);
        }
        static DateTime ReadDate()
        {
            Console.Write("Дата (дд.мм.гггг): ");
            return DateTime.Parse(Console.ReadLine().Trim());
        }
        static string ReadNumber()
        {
            Console.Write("Номер: ");
            return Console.ReadLine().Trim();
        }
        static double ReadWeight()
        {
            Console.Write("Вес (т): ");
            return double.Parse(Console.ReadLine().Trim());
        }
        static string ReadMission()
        {
            Console.Write("Миссия: ");
            return Console.ReadLine().Trim();
        }
        static int ReadPriority()
        {
            Console.Write("Приоритет (1-3): ");
            return int.Parse(Console.ReadLine().Trim());
        }
        static bool ReadBool(string prompt)
        {
            Console.Write(prompt);
            return bool.Parse(Console.ReadLine().Trim());
        }
    }
}
