using System.IO;

namespace Projection_IS_1._1
{
    public class CarPassRecord
    {
        public DateTime Date { get; set; }
        public string LicensePlate { get; set; }
        public CarPassRecord(DateTime date, string licensePlate)
        {
            Date = date;
            LicensePlate = licensePlate;
        }
        public override string ToString()
        {
            return $"Фиксация проезда: Дата = {Date:yyyy.MM.dd}, Номер = {LicensePlate}";
        }
    }
    public class CarPassParser
    {
        public static CarPassRecord Parse (string input)
        {
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime date = ParseDate(parts[0]);
            string licensePlate = parts[1];
            return new CarPassRecord(date, licensePlate);
        }
        private static DateTime ParseDate(string dateString)
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
        static void Main(string[] args)
        {
            string path = "input.txt";
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;
                try
                {
                    CarPassRecord record = CarPassParser.Parse(line);
                    Console.WriteLine($"Строка {i + 1}: {record}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Строка {i + 1}: Ошибка — {ex.Message}");
                }
            }
        }
    }
}
