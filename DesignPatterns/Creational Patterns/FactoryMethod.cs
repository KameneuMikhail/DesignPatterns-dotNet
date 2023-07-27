namespace DesignPatterns.Creational
{
    /// <summary>
    /*
     Паттерн Фабричный метод предлагает создавать объекты не напрямую, используя оператор new, а через вызов особого фабричного метода.
    Не пугайтесь, объекты всё равно будут создаваться при помощи new, но делать это будет фабричный метод.

    Чтобы эта система заработала, все возвращаемые объекты должны иметь общий интерфейс. Подклассы смогут производить объекты различных классов, следующих одному и тому же интерфейсу.

    Например, классы Грузовик и Судно реализуют интерфейс Транспорт с методом доставить. Каждый из этих классов реализует метод по-своему: грузовики везут грузы по земле, а суда — по морю.
    Фабричный метод в классе ДорожнойЛогистики вернёт объект-грузовик, а класс МорскойЛогистики — объект-судно.

    Для клиента фабричного метода нет разницы между этими объектами, так как он будет трактовать их как некий абстрактный Транспорт.
    Для него будет важно, чтобы объект имел метод доставить, а как конкретно он работает — не важно.
     */
    /// </summary>
    public class FactoryMethod
    {
        #region Transport

        public interface ITransport
        {
            public string Drive();
        }

        public class Bus : ITransport
        {
            public string Drive() => "I'm a bus";
        }

        public class Car : ITransport
        {
            public string Drive() => "I'm a car";
        }

        public class Track : ITransport
        {
            public string Drive() => "I'm a track";
        }

        #endregion

        #region Factory Method
        public interface IFactoryMethod
        {
            ITransport CreateTransport();
        }

        public class BusFactory : IFactoryMethod
        {
            public ITransport CreateTransport() => new Bus();
        }

        public class CarFactory : IFactoryMethod
        {
            public ITransport CreateTransport() => new Car();
        }

        public class TrackFactory : IFactoryMethod
        {
            public ITransport CreateTransport() => new Track();
        }

        #endregion

        #region Usage

        public class FactoryMethodClient
        {
            public static ITransport CreateTransport(IFactoryMethod method) => method.CreateTransport();
        }

        #endregion

    }
}
