using System;

namespace Lab2
{
    internal class Report
    {
        private string _heading;
        private string _content;
        private DateTime _creationDate;
        private int _rating;

        internal Report(string heading, string content) //Оглавление и содержание
        {
            _heading = heading;
            _content = content;
            _creationDate = DateTime.Now;
            _rating = 0;
        }

        internal void ShowReport()
        {
            Console.WriteLine("Название: " + _heading);
            Console.WriteLine("Рейтинг: " + _rating);
            Console.WriteLine("Создан: " + _creationDate);
            Console.WriteLine("Содержание: " + _content + "\n");
        }
        internal void ShowReportHeadingWithRating() { Console.WriteLine("Название: " + _heading + "\tРейтинг: " + _rating); }
        internal void RatingUp() { _rating++; }
        internal void RatingDown() { _rating--; }


        internal string GetHeading() { return _heading; }
        internal int GetRating() { return _rating; }
        
    }
}
