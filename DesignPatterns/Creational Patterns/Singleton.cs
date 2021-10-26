using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /*
     Все реализации одиночки сводятся к тому, чтобы скрыть конструктор по умолчанию и создать публичный статический метод, который и будет контролировать жизненный цикл объекта-одиночки.

    Если у вас есть доступ к классу одиночки, значит, будет доступ и к этому статическому методу. Из какой точки кода вы бы его ни вызвали, он всегда будет отдавать один и тот же объект.
     */
    /// </summary>
    public class Singleton
    {
        private static Lazy<Singleton> instance = new Lazy<Singleton>(() => new Singleton());

        private Singleton() { }

        public static Singleton Instance { get { return instance.Value; } }
    }
}
