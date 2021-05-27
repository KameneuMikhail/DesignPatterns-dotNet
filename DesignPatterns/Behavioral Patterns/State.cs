namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Паттерн Состояние невозможно рассматривать в отрыве от концепции машины состояний, также известной как стейт-машина или конечный автомат.

    Основная идея в том, что программа может находиться в одном из нескольких состояний, которые всё время сменяют друг друга. Набор этих состояний, а также переходов между ними, предопределён и конечен. Находясь в разных состояниях, программа может по-разному реагировать на одни и те же события, которые происходят с ней.

    Такой подход можно применить и к отдельным объектам. Например, объект Документ может принимать три состояния: Черновик, Модерация или Опубликован. В каждом из этих состоянии метод опубликовать будет работать по-разному:

    Из черновика он отправит документ на модерацию.
    Из модерации — в публикацию, но при условии, что это сделал администратор.
    В опубликованном состоянии метод не будет делать ничего.

    Паттерн Состояние предлагает создать отдельные классы для каждого состояния, в котором может пребывать объект, а затем вынести туда поведения, соответствующие этим состояниям.

    Вместо того, чтобы хранить код всех состояний, первоначальный объект, называемый контекстом, будет содержать ссылку на один из объектов-состояний и делегировать ему работу, зависящую от состояния.

    Благодаря тому, что объекты состояний будут иметь общий интерфейс, контекст сможет делегировать работу состоянию, не привязываясь к его классу. Поведение контекста можно будет изменить в любой момент, подключив к нему другой объект-состояние.

    Очень важным нюансом, отличающим этот паттерн от Стратегии, является то, что и контекст, и сами конкретные состояния могут знать друг о друге и инициировать переходы от одного состояния к другому.
     */
    /// </summary>
    public class State
    {
        #region Document

        public class Document
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        #endregion

        #region Context

        public class DocumentContext
        {
            private StateBase state;
            public DocumentContext(StateBase state)
            {
                this.ChangeState(state);
            }

            public void ChangeState(StateBase state)
            {
                this.state = state;
                this.state.SetContext(this);
            }

            public string Publish(Document doc)
            {
                return state.Publish(doc);
            }
        }

        #endregion

        #region State

        public abstract class StateBase
        {
            protected DocumentContext context;

            public abstract string Publish(Document doc);
            public void SetContext(DocumentContext context)
            {
                this.context = context;
            }
        }

        public class DraftState : StateBase
        {
            public override string Publish(Document doc)
            {
                this.context.ChangeState(new ReleaseState());
                return $"Draft - { doc.Name} ";
            }
        }

        public class ReleaseState : StateBase
        {
            public override string Publish(Document doc) => $"Release - {doc.Name} ";
        }

        #endregion
    }
}
