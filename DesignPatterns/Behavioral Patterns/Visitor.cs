namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Ваша команда разрабатывает приложение, работающее с геоданными в виде графа. Узлами графа являются городские локации: памятники, театры, рестораны, важные предприятия и прочее. Каждый узел имеет ссылки на другие, ближайшие к нему узлы. Каждому типу узлов соответствует свой класс, а каждый узел представлен отдельным объектом.

    Ваша задача — сделать экспорт этого графа в XML. Дело было бы плёвым, если бы вы могли редактировать классы узлов. Достаточно было бы добавить метод экспорта в каждый тип узла, а затем, перебирая узлы графа, вызывать этот метод для каждого узла. Благодаря полиморфизму, решение получилось бы изящным, так как вам не пришлось бы привязываться к конкретным классам узлов.

    Экспорт в XML вообще не уместен в рамках этих классов. Их основная задача была связана с геоданными, а экспорт выглядит в рамках этих классов чужеродно.

    Паттерн Посетитель предлагает разместить новое поведение в отдельном классе, вместо того чтобы множить его сразу в нескольких классах. Объекты, с которыми должно было быть связано поведение, не будут выполнять его самостоятельно. Вместо этого вы будете передавать эти объекты в методы посетителя.

    Код поведения, скорее всего, должен отличаться для объектов разных классов, поэтому и методов у посетителя должно быть несколько. Названия и принцип действия этих методов будет схож, но основное отличие будет в типе принимаемого в параметрах объекта, например:

    class ExportVisitor implements Visitor is
        method doForCity(City c) { ... }
        method doForIndustry(Industry f) { ... }
        method doForSightSeeing(SightSeeing ss) { ... }

    Вместо того, чтобы самим искать нужный метод, мы можем поручить это объектам, которые передаём в параметрах посетителю. А они уже вызовут правильный метод посетителя.

    // Client code
    foreach (Node node in graph)
        node.accept(exportVisitor)

    // City
    class City is
        method accept(Visitor v) is
            v.doForCity(this)
        // ...

    Как видите, изменить классы узлов всё-таки придётся. Но это простое изменение позволит применять к объектам узлов и другие поведения, ведь классы узлов будут привязаны не к конкретному классу посетителей, а к их общему интерфейсу. Поэтому если придётся добавить в программу новое поведение, вы создадите новый класс посетителей и будете передавать его в методы узлов.
     */
    /// </summary>
    public class Visitor
    {
        #region Location

        public class CityLocation
        {
            public string Title { get { return "City";  } }
            public string Export(IVisitor visitor) => visitor.Export(this);
        }

        public class RestorauntLocation
        {
            public string Title { get { return "Restoraunt"; } }
            public string Export(IVisitor visitor) => visitor.Export(this);
        }

        #endregion

        #region Visitor

        public interface IVisitor
        {
            string Export(CityLocation location);
            string Export(RestorauntLocation location);
        }

        public class LocationVisitor : IVisitor
        {
            public string Export(CityLocation location) => $"{location.Title} was Exported";
            public string Export(RestorauntLocation location) => $"{location.Title} was Exported";

        }

        #endregion

    }
}
