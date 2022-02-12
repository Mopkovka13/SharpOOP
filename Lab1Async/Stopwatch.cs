using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab12
{
    internal class Stopwatch
    {
        private List<TimeSpan> _timers;
        private bool _workStatus = false; //false - выключен / true - включен

        public Stopwatch()
        {
            _timers = new List<TimeSpan>();
        }

        internal async void Start()
        {
            if (_workStatus == true) // Если уже запущен - исключение
            {
                throw new InvalidOperationException();
            }
            else
            {
                Console.Clear();
                _workStatus = true;
                TimeSpan time = new TimeSpan(0, 0, 0);
                while(_workStatus == true)
                    await Task.Run(() => Print(ref time));
                _timers.Add(time);
            }
        }
        internal void Stop()
        {
            if (_workStatus == false) //Если уже остановлен - исключение
            {
                throw new InvalidOperationException();
            }
            else
            {
                _workStatus = false;
            }
        }
        internal static void Print(ref TimeSpan time)
        {
            Console.SetCursorPosition(0, 0); //перерисовываем консоль
            time += TimeSpan.FromSeconds(1);
            Console.WriteLine("Время: " + time);
            PrintMenu();
            Thread.Sleep(1000);
        }
        internal void ShowTimers()
        {
            Console.Clear();
            _timers.Sort();
            _timers.Reverse();
            Console.WriteLine("Список:");
            foreach (var timer in _timers)
            {
                Console.WriteLine("{0:hh\\:mm\\:ss} ", timer);
            }
            PrintMenu();
        }


        static void PrintMenu()
        {
            Console.WriteLine("1. Включить секундомер\n" +
                "2. Выключить секундомер\n" +
                "3. Вывести время по убыванию\n" +
                "4. Выключить программу\n");
        }
    }
}
