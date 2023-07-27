namespace DesignPatterns.Creational
{
    /// <summary>
    /*
     Для начала паттерн Абстрактная фабрика предлагает выделить общие интерфейсы для отдельных продуктов, составляющих семейства.
    Так, все вариации кресел получат общий интерфейс Кресло, все диваны реализуют интерфейс Диван и так далее.

    Далее вы создаёте абстрактную фабрику — общий интерфейс, который содержит методы создания всех продуктов семейства (например, создатьКресло, создатьДиван и создатьСтолик).
    Эти операции должны возвращать абстрактные типы продуктов, представленные интерфейсами, которые мы выделили ранее — Кресла, Диваны и Столики.

    Как насчёт вариаций продуктов? Для каждой вариации семейства продуктов мы должны создать свою собственную фабрику, реализовав абстрактный интерфейс.
    Фабрики создают продукты одной вариации. Например, ФабрикаМодерн будет возвращать только КреслаМодерн,ДиваныМодерн и СтоликиМодерн.

    Клиентский код должен работать как с фабриками, так и с продуктами только через их общие интерфейсы. Это позволит подавать в ваши классы любой тип фабрики и производить любые продукты, ничего не ломая.

    Для клиентского кода должно быть безразлично, с какой фабрикой работать.

    Например, клиентский код просит фабрику сделать стул. Он не знает, какого типа была эта фабрика.
    Он не знает, получит викторианский или модерновый стул. Для него важно, чтобы на стуле можно было сидеть и чтобы этот стул отлично смотрелся с диваном той же фабрики.

    Осталось прояснить последний момент: кто создаёт объекты конкретных фабрик, если клиентский код работает только с интерфейсами фабрик?
    Обычно программа создаёт конкретный объект фабрики при запуске, причём тип фабрики выбирается, исходя из параметров окружения или конфигурации.
     */
    /// </summary>
    public class AbstractFactory
    {
        #region Furniture

        public interface IChair
        {
            string Appearance();
            string Behaviour();
        }

        public interface ISofa
        {
            string Appearance();
            string Behaviour();
        }

        public interface IWardrobe
        {
            string Appearance();
            string Behaviour();
        }

        public class OldChair : IChair
        {
            public string Appearance() => "I'm old chair";

            public string Behaviour() => "Someone can sit on me";
        }

        public class OldCSofa : ISofa
        {
            public string Appearance() => "I'm old sofa";

            public string Behaviour() => "Someone can lie down on me";
        }

        public class OldWardrobe : IWardrobe
        {
            public string Appearance() => "I'm old wardrobe";

            public string Behaviour() => "Someone can have a clothes into me";
        }

        public class NewChair : IChair
        {
            public string Appearance() => "I'm new chair";

            public string Behaviour() => "Someone can sit on me";
        }

        public class NewCSofa : ISofa
        {
            public string Appearance() => "I'm new sofa";

            public string Behaviour() => "Someone can lie down on me";
        }

        public class NewWardrobe : IWardrobe
        {
            public string Appearance() => "I'm new wardrobe";

            public string Behaviour() => "Someone can have a clothes into me";
        }

        #endregion

        #region Abstract factory

        public interface IAbstractFactory
        {
            IChair CreateChair();
            ISofa CreateSofa();
            IWardrobe CreateWardrobe();
        }

        public class OldFunitureFactory : IAbstractFactory
        {
            public IChair CreateChair() => new OldChair();

            public ISofa CreateSofa() => new OldCSofa();

            public IWardrobe CreateWardrobe() => new OldWardrobe();
        }

        public class NewFunitureFactory : IAbstractFactory
        {
            public IChair CreateChair() => new NewChair();

            public ISofa CreateSofa() => new NewCSofa();

            public IWardrobe CreateWardrobe() => new NewWardrobe();
        }

        #endregion

        #region Usage

        public class AbstractFactoryClient
        {
            public static IAbstractFactory CreateOldFurbitureFactory() => new OldFunitureFactory();
            public static IAbstractFactory CreateNewFurbitureFactory() => new NewFunitureFactory();
        }

        #endregion

    }
}
