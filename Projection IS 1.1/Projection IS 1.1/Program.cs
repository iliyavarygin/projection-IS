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
                throw new ArgumentException($"Некорректный формат даты: {dateString}");
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
            Console.WriteLine("Введите данные в формате: гггг.мм.дд номер_автомобиля");
            while (true)
            {
                Console.Write("Введите данные: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }
                try
                {
                    CarPassRecord record = CarPassParser.Parse(input);
                    Console.WriteLine("Результат:");
                    Console.WriteLine(record);
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
