using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Projection_IS_1._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<RecordCar> records = Parser.LoadRecords("input.txt");
            RunMenu(records);
        }
        static void RunMenu(List<RecordCar> records)
        {
            while (true)
            {
                Console.WriteLine("1 - Показать все");
                Console.WriteLine("2 - Добавить запись");
                Console.WriteLine("0 - Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                    break;
                if (choice == "1")
                    Printer.PrintRecords(records);
                else if (choice == "2")
                    AddRecord(records);
                else
                    Console.WriteLine("Ошибка");
                Console.WriteLine();
            }
        }
        static void AddRecord(List<RecordCar> records)
        {
            RecordCar record = Reader.ReadRecord();
            if (record == null)
                return;
            records.Add(record);
            LineBuilder.AppendToFile(record, "input.txt");
            Console.WriteLine("Успешно");
        }
    }
}