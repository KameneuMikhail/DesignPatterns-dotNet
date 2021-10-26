namespace DesignPatterns.Creational
{
    /// <summary>
    /*
     Паттерн Прототип поручает создание копий самим копируемым объектам. Он вводит общий интерфейс для всех объектов, поддерживающих клонирование. Это позволяет копировать объекты, не привязываясь к их конкретным классам. Обычно такой интерфейс имеет всего один метод clone.

    Реализация этого метода в разных классах очень схожа. Метод создаёт новый объект текущего класса и копирует в него значения всех полей собственного объекта. Так получится скопировать даже приватные поля, так как большинство языков программирования разрешает доступ к приватным полям любого объекта текущего класса.

    Объект, который копируют, называется прототипом (откуда и название паттерна). Когда объекты программы содержат сотни полей и тысячи возможных конфигураций, прототипы могут служить своеобразной альтернативой созданию подклассов.
     */
    /// </summary>
    public class Prototype
    {
        #region Prototype

        public interface IHasDeepClone<T>
        {
            T DeepClone();
        }

        #endregion

        #region IRobot

        public class Description
        {
            public int Weight { get; set; }
            public int Height { get; set; }
        }

        public class Robot: IHasDeepClone<Robot>
        {
            public int Id { get; set; }

            public string Model { get; private set; }

            public Description Description { get; set; }


            public Robot(string model)
            {
                this.Model = model;
                this.Description = new Description();
            }

            public Robot DeepClone()
            {
                var robot = (Robot)this.MemberwiseClone();
                robot.Description = new Description();
                robot.Description.Height = this.Description.Height;
                robot.Description.Weight = this.Description.Weight;
                return robot;
            }
        }

        #endregion
    }
}
