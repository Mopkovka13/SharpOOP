using System;
using System.Collections.Generic;

namespace Laba5.Question
{
    internal class QuestionOneAnswer : Question, IQuestion
    {
        private int _rightAnswer; // Одиночный ответ
        public QuestionOneAnswer(string question, List<string>answerOptions, int rightAnswer)
        {
            _question = question;
            _answerOptions = answerOptions;
            _rightAnswer = rightAnswer;
        }
        public double CheckQuestion(string answer)
        {
            double result = 0;
            bool success = int.TryParse(answer, out int yourAnswer); //Проверяем число ли это
            if (success && yourAnswer == _rightAnswer) //Правильное ли это число (Совпадает ли с результатом)
                result = 1;
            return result;
        }

        public void PrintQuestion()
        {
            Console.WriteLine("\n" + _question + "   (Вопрос с одиночным выбором)");
            foreach (var answer in _answerOptions)
                Console.WriteLine(answer);
        }
    }
}
