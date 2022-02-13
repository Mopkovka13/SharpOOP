using System;
using System.Collections.Generic;

namespace Laba5.Question
{
    internal class QuestionMultipleAnswers : Question, IQuestion
    {
        List<int> _rightAnswers;
        public QuestionMultipleAnswers(string question, List<string> answerOptions, List<int> rightAnswer)
        {
            _question = question;
            _answerOptions = answerOptions;
            _rightAnswers = rightAnswer;
        }
        public void PrintQuestion()
        {
            Console.WriteLine("\n" + _question + "   (Вопрос с множественным выбором) Пример ответа: 1,3");
            foreach (var answer in _answerOptions)
                Console.WriteLine(answer);
        }
        public double CheckQuestion(string answer)
        {
            double result = 0;
            string[] yourAnswers = answer.Split(","); //Разбиваем строку по <,>
            for(int i = 0; i < yourAnswers.Length; i++)
            {
                bool success = int.TryParse( yourAnswers[i], out int yourAnswer); //Проверяем число ли это
                if (success && _rightAnswers.Contains(yourAnswer)) //Ищем его в ответах и если находим увеличиваем балл
                    result += 1;
            }
            result/= _rightAnswers.Count; // Делим кол-во наших правильных ответов на количество всего правильных ответов
            return result;
        }
    }
}
