using System;

namespace Laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySQL MySQL = new MySQL();
            PostgreSQL PostgreSQL = new PostgreSQL();
            Blog blog = new Blog();
            string choise = "";
            do
            {
                PrintMenu();
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        MySQL.Connect();
                        break;
                    case "2":
                        MySQL.Disconnect();
                        break;
                    case "3":
                        if (MySQL.CheckConnect())
                            blog.ShowReports();
                        break;
                    case "4":
                        if (MySQL.CheckConnect())
                            blog.ShowReportsByRating();
                        break;
                    case "5":
                        if (MySQL.CheckConnect())
                        {
                            Console.WriteLine("Введите свой запрос к MySQL");
                            Console.WriteLine("Запрос " + Console.ReadLine() + " отправлен");
                        }
                        break;
                    case "6":
                        PostgreSQL.Connect();
                        break;
                    case "7":
                        PostgreSQL.Disconnect();
                        break;
                    case "8":
                        if (PostgreSQL.CheckConnect())
                            blog.ShowReports();
                        break;
                    case "9":
                        if (PostgreSQL.CheckConnect())
                            blog.ShowReportsByRating();
                        break;
                    case "10":
                        if (PostgreSQL.CheckConnect())
                        {
                            Console.WriteLine("Введите свой запрос к PostgreSQL");
                            Console.WriteLine("Запрос " + Console.ReadLine() + " отправлен");
                        }
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine(choise + " - неизвестная команда");
                        break;
                }

            } while (choise != "0");
        }
        static void PrintMenu()
        {
            Console.WriteLine("1. Подключиться к MySQL\n" +
                "2. Отключиться от MySQL\n" +
                "3. MySQL <select * from blog;>\n" +
                "4. MySQL <select * from blog order by price _rating asc;>\n" +
                "5. Another request to MySQL\n" +
                "6. Подключиться к PostgreSQL\n" +
                "7. Отключиться от PostgreSQL\n" +
                "8. PostgreSQL <select * from blog;>\n" +
                "9. PostgreSQL <select * from blog order by price _rating asc;>\n" +
                "10. Another request to PostgreSQL\n" +
                "0. Exit");
        }
    }
}
