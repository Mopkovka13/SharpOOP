using System;
using System.Collections.Generic;

namespace Laba4
{
    internal class Program
    {
        static void Main(string[] args) //На примере MySQL
        {
            MySQL mySQL = new MySQL();
            PostgreSQL postgreSQL = new PostgreSQL();
            List<Query> queryList = new List<Query>()
            {
                new Query(mySQL, "SELECT * FROM CAR;"),
                new Query(postgreSQL, "INSERT INTO CAR (VIN,brand) VALUES ('123311','Audi');"),
                new Query(mySQL, "SELECT * FROM CAR WHERE (BRAND = Audi)"),

            };
            string choise = "";
            do
            {
                PrintMenu();
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1": //Create
                        Console.Clear();
                        Console.WriteLine("Выберите базу данных(MySQL/PostgreSQL)");
                        string tempDB = Console.ReadLine();
                        if(tempDB.ToLower() == "mysql")
                        {
                            Console.WriteLine("Введите запрос: ");
                            Query queryT = new Query(mySQL, Console.ReadLine());
                            queryList.Add(queryT);
                        }
                        else if(tempDB.ToLower() == "postgresql")
                        {
                            Console.WriteLine("Введите запрос: ");
                            Query queryT = new Query(postgreSQL, Console.ReadLine());
                            queryList.Add(queryT);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Нет такого выбора!");
                        }
                        break;
                    case "2": //Show
                        if(queryList.Count == 0)
                        {
                            Console.WriteLine("Запросов нет");
                        }
                        else
                        {
                            Console.Clear();
                            int Number = 0;
                            foreach (Query query in queryList)
                            {
                                Console.Write(Number++ + ") ");
                                query.Show();
                                Console.WriteLine();
                            }
                            Console.WriteLine();

                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите номер запроса: ");
                        bool successPerform = int.TryParse(Console.ReadLine(), out int tempIndex1);
                        if(successPerform && tempIndex1 < queryList.Count && tempIndex1 > -1)
                        {
                            queryList[tempIndex1].Perform();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Некорректный ввод.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Введите номер запроса: ");
                        bool successEdit = int.TryParse(Console.ReadLine(), out int tempIndex3);
                        if(successEdit && tempIndex3 < queryList.Count && tempIndex3 > -1)
                        {
                            Console.WriteLine("Введите новый запрос: ");
                            string newQuery = Console.ReadLine();
                            queryList[tempIndex3].Edit(newQuery);
                            Console.Clear();
                            Console.WriteLine("Запрос изменён");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Некорректный ввод.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Введите номер запроса: ");
                        bool successDelete = int.TryParse(Console.ReadLine(), out int tempIndex2);
                        if (successDelete && tempIndex2 < queryList.Count && tempIndex2 > -1)
                        {
                            queryList.RemoveAt(tempIndex2);
                            Console.Clear();
                            Console.WriteLine("Запрос удалён.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Некорректный ввод.");
                        }
                        break;
                    default:
                        Console.Clear();
                        break;
                    case "0":
                        break;
                }
            }while (choise != "0") ;
        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Создать запрос\n" +
                "2. Вывести запросы\n" +
                "3. Выполнить запрос\n" +
                "4. Изменить запрос\n" +
                "5. Удалить запрос\n" +
                "0. Выйти из программы");
        }
    }
}
