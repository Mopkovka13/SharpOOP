using System;
using System.Collections.Generic;

namespace Laba3
{
    internal class Blog
    {
        List<Report> _reportList;
        public Blog()
        {
            _reportList = new List<Report>()
            {
                new Report("Морковь"," - двулетнее растение (редко одно- или многолетнее) из семейства Зонтичные"),
                new Report("Лук"," - многолетнее травянистое растение, вид рода Лук (Allium) семейства Луковые"),
                new Report("Капуста","- двулетняя культура из семейства крестоцветных. Корневая система растения мощная, хорошо разветвленная.")
            };
        }

        internal void CreateReport()
        {
            Console.Clear();
            Console.WriteLine("Введите заголовок поста: ");
            string heading = Console.ReadLine();
            Console.WriteLine("Введите содержание поста: ");
            string content = Console.ReadLine();
            _reportList.Add(new Report(heading, content));
            Console.Clear();
            Console.WriteLine("Пост успешно добавлен !\n");
        }
        internal void ShowReports()
        {
            if (_reportList.Count == 0 || _reportList == null)
            {
                Console.Clear();
                Console.WriteLine("Постов пока нет");
            }
            else
            {
                Console.Clear();
                foreach (Report report in _reportList)
                {
                    report.ShowReport();
                }
            }
        }

        internal void ShowReportsByRating()
        {
            Console.Clear();
            if (_reportList.Count == 0 || _reportList == null)
            {
                Console.WriteLine("Постов пока нет");
            }
            else
            {
                Report[] SortArray = new Report[_reportList.Count]; //Создаём новый массив и копируем в него наш, чтобы наш остался неизменным
                _reportList.CopyTo(SortArray);
                for (int i = 0; i < SortArray.Length; i++)
                    for (int j = i + 1; j < SortArray.Length; j++)
                    {
                        if (SortArray[i].GetRating() > SortArray[j].GetRating())
                        {
                            Report temp = SortArray[i];
                            SortArray[i] = SortArray[j];
                            SortArray[j] = temp;
                        }
                    }
                for (int i = 0; i < SortArray.Length; i++)
                    SortArray[i].ShowReport();

            }
        }

        internal void EditRating()
        {
            Console.Clear();
            foreach (Report report in _reportList)
                report.ShowReportHeadingWithRating();
            Console.WriteLine("Введите название поста, которому хотите изменить рейтинг");
            string heading = Console.ReadLine();
            for (int i = 0; i < _reportList.Count; i++)
            {
                if (heading == _reportList[i].GetHeading())
                {
                    Console.WriteLine("Пост найден: ");
                    _reportList[i].ShowReportHeadingWithRating();
                    Console.WriteLine("Введите Up, чтобы повысить рейтинг или Down, чтобы понизить: ");
                    string temp = Console.ReadLine();
                    if (temp.ToLower() == "up")
                    {
                        _reportList[i].RatingUp();
                        Console.WriteLine("Рейтинг повышен!");
                    }
                    else if (temp.ToLower() == "down")
                    {
                        _reportList[i].RatingDown();
                        Console.WriteLine("Рейтинг понижен ;(");
                    }
                    else
                        Console.WriteLine("Такого выбора нет");
                }
            }
        }
    }
}
