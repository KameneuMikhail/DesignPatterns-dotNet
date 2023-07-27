namespace DesignPatterns.Structural
{
    /// <summary>
    /*
     Для чего вообще контролировать доступ к объектам? Рассмотрим такой пример: у вас есть внешний ресурсоёмкий объект, который нужен не все время, а изредка.

    Проблема, которую решает Заместитель
    Запросы к базе данных могут быть очень медленными.

    Мы могли бы создавать этот объект не в самом начале программы, а только тогда, когда он кому-то реально понадобится.
    Каждый клиент объекта получил бы некий код отложенной инициализации. Но, вероятно, это привело бы к множественному дублированию кода.

    В идеале, этот код хотелось бы поместить прямо в служебный класс, но это не всегда возможно.
    Например, код класса может находиться в закрытой сторонней библиотеке.

    Паттерн Заместитель предлагает создать новый класс-дублёр, имеющий тот же интерфейс, что и оригинальный служебный объект.
    При получении запроса от клиента объект-заместитель сам бы создавал экземпляр служебного объекта и переадресовывал бы ему всю реальную работу.

    Заместитель «притворяется» базой данных, ускоряя работу за счёт ленивой инициализации и кеширования повторяющихся запросов.

    Но в чём же здесь польза? Вы могли бы поместить в класс заместителя какую-то промежуточную логику, которая выполнялась бы до (или после) вызовов этих же методов в настоящем объекте.
    А благодаря одинаковому интерфейсу, объект-заместитель можно передать в любой код, ожидающий сервисный объект.
     */
    /// </summary>
    public class Proxy
    {
        #region Database
        public interface IDatabase
        {
            string Read(string query);
            string Write(string query);
            string Delete(string query);
            string Update(string query);
        }

        public class MySql : IDatabase
        {
            public string Delete(string query) => $"MySql Delete - {query}";

            public string Read(string query) => $"MySql Read - {query}";

            public string Update(string query) => $"MySql Update - {query}";

            public string Write(string query) => $"MySql Write - {query}";
        }

        #endregion

        #region Proxy

        public class DatabaseProxy : IDatabase
        {
            IDatabase mysql;

            public DatabaseProxy(IDatabase database)
            {
                mysql = database;
            }

            public string Delete(string query)
            {
                System.Console.WriteLine("Before Delete operation some extra work can be done (logging)");
                return mysql.Delete(query);
            }

            public string Read(string query)
            {
                return mysql.Read(query);
            }

            public string Update(string query)
            {
                return mysql.Update(query);
            }

            public string Write(string query)
            {
                return mysql.Write(query);
            }
        }

        #endregion

    }
}
