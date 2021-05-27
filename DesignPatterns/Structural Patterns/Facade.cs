namespace DesignPatterns.Structural
{
    /// <summary>
    /*
     Вашему коду приходится работать с большим количеством объектов некой сложной библиотеки или фреймворка. Вы должны самостоятельно инициализировать эти объекты, следить за правильным порядком зависимостей и так далее.

    В результате бизнес-логика ваших классов тесно переплетается с деталями реализации сторонних классов. Такой код довольно сложно понимать и поддерживать.

    Фасад — это простой интерфейс для работы со сложной подсистемой, содержащей множество классов. Фасад может иметь урезанный интерфейс, не имеющий 100% функциональности, которой можно достичь, используя сложную подсистему напрямую. Но он предоставляет именно те фичи, которые нужны клиенту, и скрывает все остальные.

    Фасад полезен, если вы используете какую-то сложную библиотеку со множеством подвижных частей, но вам нужна только часть её возможностей.

    К примеру, программа, заливающая видео котиков в социальные сети, может использовать профессиональную библиотеку сжатия видео. Но все, что нужно клиентскому коду этой программы — простой метод encode(filename, format). Создав класс с таким методом, вы реализуете свой первый фасад.
     */
    /// </summary>
    public class Facade
    {
        #region External Library
        public interface IMovie
        {
            string Render(string text);
            string Save(string text);
            string Export(string text);
        }

        public class ExternalMovie : IMovie
        {
            public string Export(string text) => $"Export - {text}";

            public string Render(string text) => $"Render - {text}";

            public string Save(string text) => $"Save - {text}";
        }

        #endregion

        #region Facade

        public interface IFacade
        {
            string Render(string text);
        }

        public class MovieFacade : IFacade
        {
            IMovie movie;

            public MovieFacade(IMovie movie) => this.movie = movie;

            public string Render(string text) => movie.Render(text);

        }
        #endregion
    }
}
