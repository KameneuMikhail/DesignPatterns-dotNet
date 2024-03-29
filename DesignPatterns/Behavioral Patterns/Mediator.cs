﻿using System;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /*
     Предположим, что у вас есть диалог создания профиля пользователя.
    Он состоит из всевозможных элементов управления — текстовых полей, чекбоксов, кнопок.

    Отдельные элементы диалога должны взаимодействовать друг с другом.
    Так, например, чекбокс «у меня есть собака» открывает скрытое поле для ввода имени домашнего любимца, а клик по кнопке отправки запускает проверку значений всех полей формы.

    Прописав эту логику прямо в коде элементов управления, вы поставите крест на их повторном использовании в других местах приложения.
    Они станут слишком тесно связанными с элементами диалога редактирования профиля, которые не нужны в других контекстах. Поэтому вы сможете использовать либо все элементы сразу, либо ни одного.

    Паттерн Посредник заставляет объекты общаться не напрямую друг с другом, а через отдельный объект-посредник, который знает, кому нужно перенаправить тот или иной запрос.
    Благодаря этому, компоненты системы будут зависеть только от посредника, а не от десятков других компонентов.

    Элементы интерфейса общаются через посредника.

    Основные изменения произойдут внутри отдельных элементов диалога.
    Если раньше при получении клика от пользователя объект кнопки сам проверял значения полей диалога, то теперь его единственной обязанностью будет сообщить диалогу о том, что произошёл клик.
    Получив извещение, диалог выполнит все необходимые проверки полей. Таким образом, вместо нескольких зависимостей от остальных элементов кнопка получит только одну — от самого диалога.

    Чтобы сделать код ещё более гибким, можно выделить общий интерфейс для всех посредников, то есть диалогов программы.
    Наша кнопка станет зависимой не от конкретного диалога создания пользователя, а от абстрактного, что позволит использовать её и в других диалогах.

    Таким образом, посредник скрывает в себе все сложные связи и зависимости между классами отдельных компонентов программы.
    А чем меньше связей имеют классы, тем проще их изменять, расширять и повторно использовать.
     */
    /// </summary>
    public class Mediator
    {
        #region Components

        public class Button
        {
            private IMediator mediator;
            public string Click()
            {
                mediator.Notify(this, new Random().Next(0, 2) == 1 ? "true" : "false");
                return "Cliked to the button";
            }
            public void SetMediator(IMediator mediator)
            {
                this.mediator = mediator;
            }
        }

        public class Label
        {
            IMediator mediator;
            public bool Enabled { get; set; }

            public void SetMediator(IMediator mediator)
            {
                this.mediator = mediator;
            }
        }

        #endregion

        #region Mediator

        public interface IMediator
        {
            void Notify(object sender, string action);
        }

        public class ComponentMediator : IMediator
        {
            private Button button;
            private Label label;

            public ComponentMediator(Button button, Label label)
            {
                this.button = button;
                this.button.SetMediator(this);

                this.label = label;
                this.label.SetMediator(this);
            }

            public void Notify(object sender, string action)
            {
                if (sender is Button)
                    label.Enabled = bool.Parse(action);
            }
        }
        #endregion
    }
}
