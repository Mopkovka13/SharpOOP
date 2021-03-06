using System;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Blog blog = new Blog();
            string choose;
            do
            {
                PrintMenu();
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        blog.CreateReport();
                        break;
                    case "2":
                        blog.ShowReports();
                        break;
                    case "3":
                        blog.ShowReportsByRating();
                        break;
                    case "4":
                        blog.EditRating();
                        break;
                    case "5":
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Нет такого варианта");
                        break;
                }
            } while (choose != "5");
        }
        static void PrintMenu()
        {
            Console.WriteLine("1. Добавить пост\n" +
                "2. Показать все посты\n" +
                "3. Показать посты по рейтингу\n" +
                "4. Изменить рейтинг посту\n" +
                "5. Выключить программу\n");
        }
    }
}
