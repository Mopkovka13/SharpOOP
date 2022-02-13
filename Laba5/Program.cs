using System;

namespace Laba5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            string choise = "";
            do
            {
                Console.WriteLine("Тест:\n1. По порядку\n" +
                "2. В случайном порядке\n" +
                "3. Закрыть");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        test.InOrder();
                        break;
                    case "2":
                        test.RandomOrder();
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Нет такого выбора");
                        break;
                }
            } while (choise != "3");
        }
    }
}
