using Laba5.Question;
using System;
using System.Collections.Generic;


namespace Laba5
{
    internal class Test
    {
        private double _allPoints;
        List<IQuestion> _questions;
        public Test()
        {
            _questions = new List<IQuestion>()
            {
                new QuestionOneAnswer("2+2 ?", new List<string>() { "1) 5", "2) 4", "3) 2", "4) 3"}, 2),
                new QuestionOneAnswer("Кто съел колобка ?", new List<string>() { "1) Лиса", "2) Волк", "3) Бабушка", "4) Дедушка"}, 1),
                new QuestionOneAnswer("Сколько пальцев на руке ?", new List<string>() { "1) 9", "2) 10", "3) 5", "4) 20"}, 3),
                new QuestionMultipleAnswers("Выберите овощи ", new List<string>() {"1) Банан","2) Томат", "3) Капуста", "4) Яблоко"}, new List<int>{2,3}),
                new QuestionMultipleAnswers("Институты в ВолГУ ", new List<string>() {"1) ИМИТ","2) ИЕН", "3) АТИ", "4) ИИМОСТ"}, new List<int>{1,2,4}),
                new QuestionMultipleAnswers("Цвета светофора ", new List<string>() {"1) Красный","2) Синий", "3) Желтый", "4) Зеленый"}, new List<int>{1,3,4}),
                new QuestionConsecutiveAnswers("Цифры по возрастанию ", new List<string>() {"1) 24","2) 11", "3) 15", "4) 6"}, new List<int>{4,2,3,1}),
                new QuestionConsecutiveAnswers("Буквы по алфавиту ", new List<string>() {"1) А","2) В", "3) Б", "4) Г"}, new List<int>{1,3,2,4}),
                new QuestionConsecutiveAnswers("Буквы по алфавиту(английские) ", new List<string>() {"1) B","2) A", "3) C", "4) D"}, new List<int>{2,1,3,4})
            };
        }

        internal void RandomOrder()
        {
            Console.Clear();
            _allPoints = 0;
            IQuestion[] NewArray = new IQuestion[_questions.Count]; //Создаём новый массив и копируем в него наш, чтобы наш остался в обычном порядке после перемешивания
            _questions.CopyTo(NewArray);
            IQuestion temp;
            int swapIndex;
            Random rand = new Random();
            for (int i = 0; i < NewArray.Length; i++) //Перемешиваем 1 раз
            {
                swapIndex = rand.Next(0, NewArray.Length - 1);
                temp = NewArray[i];
                NewArray[i] = NewArray[swapIndex];
                NewArray[swapIndex] = temp;
            }
            for (int i = 0; i < NewArray.Length; i++) //Перемешиваем 2 раз
            {
                swapIndex = rand.Next(0, NewArray.Length - 1);
                temp = NewArray[i];
                NewArray[i] = NewArray[swapIndex];
                NewArray[swapIndex] = temp;
            }
            foreach (var question in NewArray)
            {
                question.PrintQuestion();
                string answer = Console.ReadLine();
                _allPoints += question.CheckQuestion(answer);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ваши очки: " + _allPoints);
            Console.ResetColor();

        }

        internal void InOrder()
        {
            Console.Clear();
            _allPoints = 0;
            foreach (var question in _questions)
            {
                question.PrintQuestion();
                string answer = Console.ReadLine();
                _allPoints +=question.CheckQuestion(answer);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ваши очки: " + _allPoints);
            Console.ResetColor();
        }
    }
}
