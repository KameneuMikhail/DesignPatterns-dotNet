using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Представьте, что вы имеете два объекта: Покупатель и Магазин. В магазин вот-вот должны завезти новый товар, который интересен покупателю.

    Покупатель может каждый день ходить в магазин, чтобы проверить наличие товара.
    Но при этом он будет злиться, без толку тратя своё драгоценное время.

    С другой стороны, магазин может разослать спам каждому своему покупателю.
    Многих это расстроит, так как товар специфический, и не всем он нужен.

    Получается конфликт: либо покупатель тратит время на периодические проверки, либо магазин тратит ресурсы на бесполезные оповещения.

    Давайте называть Издателями те объекты, которые содержат важное или интересное для других состояние.
    Остальные объекты, которые хотят отслеживать изменения этого состояния, назовём Подписчиками.

    Паттерн Наблюдатель предлагает хранить внутри объекта издателя список ссылок на объекты подписчиков, причём издатель не должен вести список подписки самостоятельно.
    Он предоставит методы, с помощью которых подписчики могли бы добавлять или убирать себя из списка.

    Теперь самое интересное. Когда в издателе будет происходить важное событие, он будет проходиться по списку подписчиков и оповещать их об этом, вызывая определённый метод объектов-подписчиков.

    Издателю безразлично, какой класс будет иметь тот или иной подписчик, так как все они должны следовать общему интерфейсу и иметь единый метод оповещения.

    Увидев, как складно всё работает, вы можете выделить общий интерфейс, описывающий методы подписки и отписки, и для всех издателей. После этого подписчики смогут работать с разными типами издателей, а также получать оповещения от них через один и тот же метод.
     */
    /// </summary>
    public class Observer
    {
        public class Shop
        {
            public string Name { get; set; }
        }

        #region Observer

        public class Consumer : IObserver<Shop>
        {
            IDisposable unSubscriber;
            public void Subscribe(IObservable<Shop> observable)
            {
                unSubscriber = observable.Subscribe(this);
            }
            public void OnCompleted()
            {
                unSubscriber.Dispose();
            }

            public void OnError(Exception error)
            {
                // log errors
            }

            public void OnNext(Shop value)
            {
                Console.WriteLine($"Shop - { value.Name }");
            }
        }

        #endregion

        #region Observable

        public class ShopObservable : IObservable<Shop>
        {
            private IList<IObserver<Shop>> observers;
            private Shop shop;

            public ShopObservable(Shop shop)
            {
                observers = new List<IObserver<Shop>>();
                this.shop = shop;
            }

            public IDisposable Subscribe(IObserver<Shop> observer)
            {
                observers.Add(observer);
                return new Unsubscriber(observers, observer);
            }

            public void Notify()
            {
                foreach(var obs in observers)
                {
                    obs.OnNext(shop);
                }
            }
        }
        #endregion

        #region Unsubscriber

        public class Unsubscriber : IDisposable
        {
            private IList<IObserver<Shop>> observers;
            IObserver<Shop> observer;
            private bool isDisposed = false;

            public Unsubscriber(IList<IObserver<Shop>> observers, IObserver<Shop> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                Dispose(true);
            }

            
            private void Dispose(bool isDisposing)
            {
                if (isDisposed)
                    return;

                if (isDisposing)
                    observers.Remove(observer);

                isDisposed = true;
            }
        }

        #endregion
    }
}
