using System;

namespace Lab12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            TimeSpan StartTime = new TimeSpan(0, 0, 0);
            string choose;
            PrintMenu();
            do
            {
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        StartTime = DateTime.Now.TimeOfDay;
                        stopwatch.Start(StartTime);
                        break;
                    case "2":
                         stopwatch.Stop(StartTime);
                        break;
                    case "3":
                        stopwatch.ShowTimers();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Нет такого варианта");
                        break;
                }
            } while (choose != "4");
        }


        static void PrintMenu()
        {
            Console.WriteLine("1. Включить секундомер\n" +
                "2. Выключить секундомер\n" +
                "3. Вывести время по убыванию\n" +
                "4. Выключить программу\n");
        }
    }
}
