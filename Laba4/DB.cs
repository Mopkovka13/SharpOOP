using System;

namespace Laba4
{
    class DB
    {
        internal string _typeConnect; //Тип соединения, получаем от СУБД
        private bool _connection = false; //Есть ли сейчас подключение к БД
        private DateTime _connectTime; //Когда было подключено
        private const int _workTime = 10; // Время, которое будет работать подключение (По заданию 10 секунд, но это мало)

        internal void Connect()
        {
            if (_connection == false) //Если подключения нет - подключить
            {
                _connection = true;
                Console.Clear();
                Console.WriteLine("Подключение к " + _typeConnect + " выполнено\n");
                _connectTime = DateTime.Now;
            }
            else //Иначе сбросить время подключения
            {
                Console.Clear();
                Console.WriteLine("Подключение к " + _typeConnect + " уже выполнено, время подключения обновлено\n");
                _connectTime = DateTime.Now;
            }
        }

        internal void Disconnect()
        {
            if (_connection == true) //Если подключение есть - отключить
            {
                _connection = false;
                Console.Clear();
                Console.WriteLine("Подключение к " + _typeConnect + " разорвано\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Подключение к " + _typeConnect + " отсутствует\n");
            }
        }

        internal bool CheckConnect()
        {
            bool check = false;
            if (_connection == false)
            {
                Console.Clear();
                Console.WriteLine("Подключение к " + _typeConnect + " отсутствует\n");
            }
            else if ((DateTime.Now - _connectTime).TotalSeconds >= _workTime) //Если время работы истекло
            {
                Console.Clear();
                Console.WriteLine("Время подключения к " + _typeConnect + " истекло\n");
                _connection = false; //Соединение разрывается
            }
            else
            {
                check = true;
            }
            return check;
        }
    }
}
