﻿namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Вы решили написать приложение-навигатор для путешественников. Оно должно показывать красивую и удобную карту, позволяющую с лёгкостью ориентироваться в незнакомом городе на машине.

    Через некоторое время выяснилось, что некоторые люди предпочитают ездить по городу на общественном транспорте. Поэтому вы добавили и такую опцию прокладывания пути.

    С каждым новым алгоритмом код основного класса навигатора увеличивался вдвое.

    Паттерн Стратегия предлагает определить семейство схожих алгоритмов, которые часто изменяются или расширяются, и вынести их в собственные классы, называемые стратегиями.

    Вместо того, чтобы изначальный класс сам выполнял тот или иной алгоритм, он будет играть роль контекста, ссылаясь на одну из стратегий и делегируя ей выполнение работы. Чтобы сменить алгоритм, вам будет достаточно подставить в контекст другой объект-стратегию.

    Важно, чтобы все стратегии имели общий интерфейс. Используя этот интерфейс, контекст будет независимым от конкретных классов стратегий. С другой стороны, вы сможете изменять и добавлять новые виды алгоритмов, не трогая код контекста.

    В нашем примере каждый алгоритм поиска пути переедет в свой собственный класс. В этих классах будет определён лишь один метод, принимающий в параметрах координаты начала и конца пути, а возвращающий массив точек маршрута.

    Хотя каждый класс будет прокладывать маршрут по-своему, для навигатора это не будет иметь никакого значения, так как его работа заключается только в отрисовке маршрута. Навигатору достаточно подать в стратегию данные о начале и конце маршрута, чтобы получить массив точек маршрута в оговорённом формате.

    Класс навигатора будет иметь метод для установки стратегии, позволяя изменять стратегию поиска пути на лету. Такой метод пригодится клиентскому коду навигатора, например, переключателям типов маршрутов в пользовательском интерфейсе.
     */
    /// </summary>
    public class Strategy
    {
        #region Type of navigation

        public interface IBuildRoute
        {
            public string BuildRoute();
        }

        public class CarNavigation : IBuildRoute
        {
            public string BuildRoute() => "Route is created by car";
        }

        public class PublicNavigation : IBuildRoute
        {
            public string BuildRoute() => "Route is created by public transport";
        }

        #endregion

        #region Strategy

        public class NavigationStrategy
        {
            IBuildRoute buildRoute;

            public NavigationStrategy(IBuildRoute buildRoute)
            {
                this.buildRoute = buildRoute;
            }

            public void SetStrategy(IBuildRoute buildRoute)
            {
                this.buildRoute = buildRoute;
            }

            public string BuildRoute() => buildRoute.BuildRoute();
        }

        #endregion
    }
}