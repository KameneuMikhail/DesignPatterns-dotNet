﻿namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Вы пишете программу для дата-майнинга в офисных документах. Пользователи будут загружать в неё документы в разных форматах (PDF, DOC, CSV), а программа должна извлекать из них полезную информацию.

    В первой версии вы ограничились только обработкой DOC-файлов. В следующей версии добавили поддержку CSV. А через месяц прикрутили работу с PDF-документами.

    В какой-то момент вы заметили, что код всех трёх классов обработки документов хоть и отличается в части работы с файлами, но содержат довольно много общего в части самого извлечения данных. Было бы здорово избавится от повторной реализации алгоритма извлечения данных в каждом из классов.

    К тому же остальной код, работающий с объектами этих классов, наполнен условиями, проверяющими тип обработчика перед началом работы. Весь этот код можно упростить, если слить все три класса воедино либо свести их к общему интерфейсу.

    Паттерн Шаблонный метод предлагает разбить алгоритм на последовательность шагов, описать эти шаги в отдельных методах и вызывать их в одном шаблонном методе друг за другом.

    Это позволит подклассам переопределять некоторые шаги алгоритма, оставляя без изменений его структуру и остальные шаги, которые для этого подкласса не так важны.

    В нашем примере с дата-майнингом мы можем создать общий базовый класс для всех трёх алгоритмов. Этот класс будет состоять из шаблонного метода, который последовательно вызывает шаги разбора документов.

    Шаблонный метод разбивает алгоритм на шаги, позволяя подклассам переопределить некоторые из них.

    Для начала шаги шаблонного метода можно сделать абстрактными. Из-за этого все подклассы должны будут реализовать каждый из шагов по-своему. В нашем случае все подклассы и так содержат реализацию каждого из шагов, поэтому ничего дополнительно делать не нужно.

    По-настоящему важным является следующий этап. Теперь мы можем определить общее для всех классов поведение и вынести его в суперкласс. В нашем примере шаги открытия, считывания и закрытия могут отличаться для разных типов документов, поэтому останутся абстрактными. А вот одинаковый для всех типов документов код обработки данных переедет в базовый класс.

    Как видите, у нас получилось два вида шагов: абстрактные, которые каждый подкласс обязательно должен реализовать, а также шаги с реализацией по умолчанию, которые можно переопределять в подклассах, но не обязательно.

    Но есть и третий тип шагов — хуки: их не обязательно переопределять, но они не содержат никакого кода, выглядя как обычные методы. Шаблонный метод останется рабочим, даже если ни один подкласс не переопределит такой хук. Однако, хук даёт подклассам дополнительные точки «вклинивания» в шаблонный метод.
     */
    /// </summary>
    public class TemplateMethod
    {
        #region Template method

        public interface IDocument
        {
            string Do();
        }

        public abstract class DocumentReader: IDocument
        {
            public abstract string ReadDocument();
            public abstract string CloseDocument();
            public virtual string UpdateDoc() { return string.Empty; }

            public string Do()
            {
                return $"Document was {ReadDocument()}, {UpdateDoc()}, {CloseDocument()}";
            }
        }

        public class PDFReader : DocumentReader
        {
            public override string CloseDocument() => "PDF is closed";

            public override string ReadDocument() => "PDF is opened";
        }

        public class DocReader : DocumentReader
        {
            public override string CloseDocument() => "Doc is closed";

            public override string ReadDocument() => "Doc is opened";

            public override string UpdateDoc() => "Doc is updated";
        }

        #endregion
    }
}