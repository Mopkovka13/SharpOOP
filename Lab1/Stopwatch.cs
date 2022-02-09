using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Stopwatch
    {
        private List<TimeSpan> _timers = new List<TimeSpan>();
        private bool _workStatus = false; //false - выключен / true - включен
        
        internal TimeSpan Start()
        {
            if(_workStatus==true) // Если уже запущен - исключение
            {
                throw new InvalidOperationException();
            }
            else
            {
                _workStatus = true;
                TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
                Console.WriteLine("Время начала: {0:hh\\:mm\\:ss}", CurrentTime); //Из-за такого вывода может быть погрешность на 1 секунду, как вариант
                                                                                  //Console.WriteLine("Время начала: " + CurrentTime); //но тогда будут милисекунды
                return CurrentTime;
            }
        }

        /// <summary>
        /// Передаём Start, чтобы посчитать разницу во времени
        /// </summary>
        internal void Stop(TimeSpan StartTime)
        {
            if(_workStatus == false) //Если уже остановлен - исключение
            {
                throw new InvalidOperationException();
            }
            else
            {
                _workStatus = false;
                TimeSpan CurrentTime = DateTime.Now.TimeOfDay;
                Console.WriteLine("Время окончания: {0:hh\\:mm\\:ss}", CurrentTime);
                _timers.Add(CurrentTime - StartTime);
            }
        }

        internal void ShowTimers()
        {
            _timers.Sort();
            _timers.Reverse();
            foreach(var timer in _timers)
            {
                Console.WriteLine("{0:hh\\:mm\\:ss} ", timer);
            }
        }
    }
}
