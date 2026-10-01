using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projection_IS_1._1
{
    public class Parser
    {
        public static List<RecordCar> LoadRecords(string path)
        {
            string[] lines = File.ReadAllLines(path);
            return Parse(lines);
        }
        public static List<RecordCar> Parse(string[] lines)
        {
            List<RecordCar> records = new List<RecordCar>();
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                RecordCar record = ParseLine(line);
                if (record != null) records.Add(record);
            }
            return records;
        }
        public static RecordCar ParseLine(string line)
        {
            string[] parts = line.Split('|');
            string type = parts[0];
            if (type == "car") return ParseCar(parts);
            if (type == "truck") return ParseTruck(parts);
            if (type == "special") return ParseSpecialCar(parts);
            return null;
        }
        public static RecordCar ParseCar(string[] parts)
        {
            DateTime date = DateTime.Parse(parts[1]);
            string number = parts[2];
            return new RecordCar(date, number);
        }
        public static RecordCar ParseTruck (string[] parts)
        {
            DateTime date = DateTime.Parse(parts[1]);
            string number = parts[2];
            double weight = double.Parse(parts[3]);
            bool haveDangareCargo = bool.Parse(parts[4]);
            return new RecordTruck(date, number, weight, haveDangareCargo);
        }
        public static RecordCar ParseSpecialCar (string[] parts)
        {
            DateTime date = DateTime.Parse(parts[1]);
            string number = parts[2];
            string mission = parts[3];
            int priority = int.Parse(parts[4]);
            return new RecordSpecialCar(date, number, mission, priority);
        }
    }
}
