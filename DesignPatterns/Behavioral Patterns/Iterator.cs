using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Коллекции — самая распространённая структура данных, которую вы можете встретить в программировании. Это набор объектов, собранный в одну кучу по каким-то критериям.

    Большинство коллекций выглядят как обычный список элементов. Но есть и экзотические коллекции, построенные на основе деревьев, графов и других сложных структур данных.

    Но как бы ни была структурирована коллекция, пользователь должен иметь возможность последовательно обходить её элементы, чтобы проделывать с ними какие-то действия.

    Но каким способом следует перемещаться по сложной структуре данных? Например, сегодня может быть достаточным обход дерева в глубину, но завтра потребуется возможность перемещаться по дереву в ширину. А на следующей неделе и того хуже — понадобится обход коллекции в случайном порядке.

    Добавляя всё новые алгоритмы в код коллекции, вы понемногу размываете её основную задачу, которая заключается в эффективном хранении данных. Некоторые алгоритмы могут быть и вовсе слишком «заточены» под определённое приложение и смотреться дико в общем классе коллекции.

    Идея паттерна Итератор состоит в том, чтобы вынести поведение обхода коллекции из самой коллекции в отдельный класс.

    Итераторы содержат код обхода коллекции. Одну коллекцию могут обходить сразу несколько итераторов.

    Объект-итератор будет отслеживать состояние обхода, текущую позицию в коллекции и сколько элементов ещё осталось обойти. Одну и ту же коллекцию смогут одновременно обходить различные итераторы, а сама коллекция не будет даже знать об этом.

    К тому же, если вам понадобится добавить новый способ обхода, вы сможете создать отдельный класс итератора, не изменяя существующий код коллекции.
     */
    /// </summary>
    public class Iterator
    {
        #region Address Book

        public class Record
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public Record(string name, string address)
            {
                this.Name = name;
                this.Address = address;
            }
        }

        public class AddressBook<Record> : IteratorAggregate<Record>
        {
            private IList<Record> records = new List<Record>();
            private bool direction = false;

            public void ReverseDirection()
            {
                direction = !direction;
            }

            public override IEnumerator<Record> GetEnumerator()
            {
                return new AlphabeticalOrderIterator<Record>(this, direction);
            }

            public void Add(Record item)
            {
                this.records.Add(item);
            }

            public IList<Record> GetItems()
            {
                return records;
            }
        }

        #endregion
        #region Iterator

        public abstract class IteratorBase<T> : IEnumerator<T>
        {
            T IEnumerator<T>.Current => Current();

            object IEnumerator.Current => Current();

            public abstract bool MoveNext();

            public abstract void Reset();

            public abstract T Current();

            public void Dispose()
            { }
        }

        public abstract class IteratorAggregate<T> : IEnumerable<T>
        {
            public abstract IEnumerator<T> GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new System.NotImplementedException();
            }
        }

        public class AlphabeticalOrderIterator<Record> : IteratorBase<Record>
        {
            private AddressBook<Record> addressBook;
            private int position = -1;
            private bool isReverse = false;

            public AlphabeticalOrderIterator(AddressBook<Record> addressBook, bool isReverse = false)
            {
                this.addressBook = addressBook;
                this.isReverse = isReverse;

                if (isReverse)
                    position = this.addressBook.GetItems().Count;
            }
            public override Record Current()
            {
                return this.addressBook.GetItems()[position];
            }

            public override bool MoveNext()
            {
                int updatedPosition = this.position + (this.isReverse ? -1 : 1);

                if (updatedPosition >= 0 && updatedPosition < this.addressBook.GetItems().Count)
                {
                    this.position = updatedPosition;
                    return true;
                }
                else
                    return false;
            }

            public override void Reset()
            {
                this.position = this.isReverse ? this.addressBook.GetItems().Count - 1 : 0;
            }
        }

        #endregion
    }
}
