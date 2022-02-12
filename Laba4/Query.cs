using System;
using System.Threading;

namespace Laba4
{
    internal class Query
    {
        private DB _db { get; }
        private string _request;
        public Query(DB db, string request)
        {
            _db = db;
            _request = request;
        }
        internal void Show()
        {
            Console.Write("База данных: " + _db._typeConnect + " Запрос: " + _request);
        }
        internal void Edit(string request)
        {
            _request = request;
        }
        internal void Perform()
        {
            _db.Connect();
            if(_db.CheckConnect())
            {
                Thread.Sleep(3000);
                Console.WriteLine("Запрос: " + _request + " выполен в " + _db._typeConnect);
                Thread.Sleep(4000);
            }
            _db.Disconnect();
        }
    }
}
