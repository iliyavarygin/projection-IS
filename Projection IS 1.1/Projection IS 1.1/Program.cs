using System.IO;

namespace Projection_IS_1._1
{
    public class CarPassRecord
    {
        public DateTime Date { get; set; }
        public string LicensePlate { get; set; }
        public bool Nar { get; set; }
        public CarPassRecord(DateTime date, string licensePlate, bool hasnar)
        {
            Date = date;
            LicensePlate = licensePlate;
            Nar = hasnar;
        }
        public override string ToString()
        {
            string status = Nar ? "нарушитель" : "не нарушитель";
            return $"Фиксация проезда: Дата = {Date:yyyy.MM.dd}, Номер = {LicensePlate} - {status}";
        }
    }
    public class CarPassParser
    {
        public static CarPassRecord Parse(string input)
        {
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime date = ParseDate(parts[0]);
            string licensePlate = parts[1];
            bool hasnar = parts[parts.Length - 1] == "1";
            return new CarPassRecord(date, licensePlate, hasnar);
        }
        public static DateTime ParseDate(string dateString)
        {
            string[] dateParts = dateString.Split('.');
            if (dateParts.Length != 3)
            {
                throw new ArgumentException($"Неправильный формат даты: {dateString}");
            }
            int year = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int day = int.Parse(dateParts[2]);
            return new DateTime(year, month, day);
        }
    }
    class Program
    {
        static void RemoveCar(List<CarPassRecord> records)
        {
            for (int k = 0; k < 2; k++)
            {
                int minIndex = -1;
                for (int i = 0; i < records.Count; i++)
                {
                    if (!records[i].Nar)
                        continue;
                    if (minIndex == -1 || records[i].Date.Year < records[minIndex].Date.Year)
                        minIndex = i;
                }
                if (minIndex == -1)
                    break;
                records.RemoveAt(minIndex);
            }
        }
        static void Main(string[] args)
        {
            string path = "input.txt";
            string[] lines = File.ReadAllLines(path);
            List<CarPassRecord> records = new List<CarPassRecord>();
            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;
                try
                {
                    records.Add(CarPassParser.Parse(trimmed));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Пропущена строка: {ex.Message}");
                }
            }
            RemoveCar(records);
            foreach (var r in records)
                Console.WriteLine(r);
            Console.ReadKey();
        }
    }
}
